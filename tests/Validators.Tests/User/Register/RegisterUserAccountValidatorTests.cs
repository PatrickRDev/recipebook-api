using CommonTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Exception;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact] //[theory] é de bom tom deixar assim comentado para mostrar que poderia fazer de outro modo ?
    public void Success()
    {
        //AAA

        //Arrange

        var request = RequestRegisterUserAccountJsonBuilder.Build();


        var validator = new RegisterUserAccountValidator();

        //Action

        var result = validator.Validate(request);

        //Assert

        result.IsValid.ShouldBeTrue();

    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("      ")]
    [SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Pending>")]
    public void Validate_ShouldHaveError_WhenNameIsEmpty(string name)
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = name;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errorList =>
        {
            errorList.Count.ShouldBe(1);
            errorList.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_NAME_REQUIRED));
        });

    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        request.Email = string.Empty;

        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED));
        });

    }

    [Fact]
    public void Validate_ShouldHaveError_WhenPasswordIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_PASSWORD_REQUIRED));
        });
    }


    [Fact]

    public void Validate_shouldHaveError_WhenEmailIsInvalid()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email= "invalid-email";

        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_EMAIL_INVALID));
        });


    }


}

