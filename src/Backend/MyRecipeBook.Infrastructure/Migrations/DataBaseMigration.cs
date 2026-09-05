using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MyRecipeBook.Infrastructure.Migrations;

public class DataBaseMigration
{
    public static void ExecuteMigrations(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();
        runner.MigrateUp();
    }
}
