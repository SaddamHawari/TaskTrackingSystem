using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskTrackingSystem.Data;
using Volo.Abp.DependencyInjection;

namespace TaskTrackingSystem.EntityFrameworkCore;

public class EntityFrameworkCoreTaskTrackingSystemDbSchemaMigrator
    : ITaskTrackingSystemDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTaskTrackingSystemDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TaskTrackingSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TaskTrackingSystemDbContext>()
            .Database
            .MigrateAsync();
    }
}
