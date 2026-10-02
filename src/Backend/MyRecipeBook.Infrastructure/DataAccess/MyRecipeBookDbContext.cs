using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("WebApi.Tests")] 
namespace MyRecipeBook.Infrastructure.DataAccess;

internal class MyRecipeBookDbContext : DbContext
{
    private readonly string _DbContext;

    public MyRecipeBookDbContext(DbContextOptions DbcontextOptions) : base(DbcontextOptions) { }


    public DbSet<User> Users { get; set; }

}
