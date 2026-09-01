using Mapster;
using MyRecipeBook.Communication.ExceptionsBase;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase
{
    public void Execute(RequestRegisterUserAccountJson request)
    {
        //Registo a conta de uma pessoa. 
        ValidationAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

    }

    public void ValidationAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();


            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
