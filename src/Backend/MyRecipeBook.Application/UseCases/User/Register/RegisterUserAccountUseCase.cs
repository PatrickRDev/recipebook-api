using FluentValidation.Results;
using Mapster;
using MyRecipeBook.Communication.ExceptionsBase;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHashing _passwordHashing;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    public RegisterUserAccountUseCase(IPasswordHashing passwordHashing,
           IUserWriteOnlyRepository userWriteOnlyRepository,
           IUserReadOnlyRepository userReadOnlyRepository,      
           IUnitOfWork unitOfWork)
    {
        
        _passwordHashing = passwordHashing;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request)
    {
        //Registo a conta de uma pessoa. 
        await ValidationAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHashing.HashPassword(request.Password);

        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,

        };

    }

    public async Task ValidationAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty,ResourceMessagesException.VALIDATION_EMAIL_ALREADY_EXISTS));
        }


        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();


            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
