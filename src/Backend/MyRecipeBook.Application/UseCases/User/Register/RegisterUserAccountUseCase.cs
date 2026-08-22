using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase
{
    public void Execute(RequestRegisterUserAccountJson request)
    {
        //Registo a conta de uma pessoa. 

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
    }
}
