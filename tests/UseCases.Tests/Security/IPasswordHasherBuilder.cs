using Moq;
using MyRecipeBook.Domain.Security.PasswordHashing;

namespace UseCases.Tests.Security;

public class IPasswordHasherBuilder
{

    private readonly Mock<IPasswordHashing> _mock;

    public IPasswordHasherBuilder()
    {
        _mock = new Mock<IPasswordHashing>();
        _mock.Setup(hasher => hasher.HashPassword(It.IsAny<string>())).Returns("hashed_password");
    }

    public void VerifyPassword(string password)
    {
        _mock.Setup(repository => repository.VerifyPassword(password, It.IsAny<string>())).Returns(true);
    }

    public IPasswordHashing Build()
    {
        return _mock.Object;
    }
}
