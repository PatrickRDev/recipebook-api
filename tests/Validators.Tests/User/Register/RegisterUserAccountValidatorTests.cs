using CommonTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact] //[theory] é de bom tom deixar assim comentado para mostrar que poderia fazer de outro modo ?
    public void Success()
    {
        //AAA

        //Arrange

        var request =  RequestRegisterUserAccountJsonBuilder.Build();


        var validator = new RegisterUserAccountValidator();

        //Action

       var result = validator.Validate(request);

        //Assert

        Assert.True(result.IsValid);

    }
}

