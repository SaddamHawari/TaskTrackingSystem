using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TaskTrackingSystem.Data;

/* This is used if database provider does't define
 * ITaskTrackingSystemDbSchemaMigrator implementation.
 */
public class NullTaskTrackingSystemDbSchemaMigrator : ITaskTrackingSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
