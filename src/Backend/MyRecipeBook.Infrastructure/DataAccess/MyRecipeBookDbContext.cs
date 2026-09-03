using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Infrastructure.DataAccess;

internal class MyRecipeBookDbContext : DbContext
{
    private readonly string _DbContext;

    public MyRecipeBookDbContext(DbContextOptions DbcontextOptions) : base(DbcontextOptions) { }


    public DbSet<User> Users { get; set; }

}
