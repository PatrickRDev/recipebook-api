using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;
using Microsoft.Extensions.Configuration;
using MyRecipeBook.Domain.Repositories;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{

    extension(IServiceCollection services)
    {
        public void AddInfrastructureServices(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            // services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddDbContext<MyRecipeBookDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("MySqlConnection")!;
                config.UseMySQL(connectionString);
            });

          /*  services.AddDbContext<MyRecipeBookDbContext>(options =>
            {

                options.UseSqlServer("Server=localhost;Database=meulivrodereceitas;User Id=sa;Password=@Password123;TrustServerCertificate=True;");
            }); */
               

            
            
        }

       
    }








  /* public static void  AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
    }
  */
}
