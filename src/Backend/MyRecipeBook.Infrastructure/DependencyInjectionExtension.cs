using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{

    extension(IServiceCollection services)
    {
        public void AddInfrastructureServices()
        {
            services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
        }
    }








  /* public static void  AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
    }
  */
}
