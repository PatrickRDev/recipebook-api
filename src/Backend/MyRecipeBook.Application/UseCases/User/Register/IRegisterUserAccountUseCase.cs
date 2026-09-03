using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;

namespace MyRecipeBook.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase 
{
     Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request);
}
