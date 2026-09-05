using Bogus;
using MyRecipeBook.Communication.Request;

namespace CommonTestUtilities.Requests;

public class RequestRegisterUserAccountJsonBuilder
{
    public static RequestRegisterUserAccountJson Build()
    {
        return new Faker<RequestRegisterUserAccountJson>()
             .RuleFor(x => x.Name, f => f.Person.FullName)
             .RuleFor(x => x.Email,(f,user) => f.Internet.Email(user.Name))
             .RuleFor(x => x.Password, f => f.Internet.Password())
             .Generate();
    }
}
