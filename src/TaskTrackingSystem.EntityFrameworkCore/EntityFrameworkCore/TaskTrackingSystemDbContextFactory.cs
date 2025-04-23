using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskTrackingSystem.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TaskTrackingSystemDbContextFactory : IDesignTimeDbContextFactory<TaskTrackingSystemDbContext>
{
    public TaskTrackingSystemDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var configuration = BuildConfiguration();
        
        TaskTrackingSystemEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<TaskTrackingSystemDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));
        
        return new TaskTrackingSystemDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TaskTrackingSystem.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
