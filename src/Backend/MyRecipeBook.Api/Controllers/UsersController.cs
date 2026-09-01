using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]


public class UsersController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase useCase)
    {
        //Registo a conta de uma pessoa. 
       // var useCase = new RegisterUserAccountUseCase();
        useCase.Execute(request);
        return Created();
    }

}
