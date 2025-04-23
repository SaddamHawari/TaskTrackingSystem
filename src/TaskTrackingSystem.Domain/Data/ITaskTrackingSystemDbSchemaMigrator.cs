using System.Threading.Tasks;

namespace TaskTrackingSystem.Data;

public interface ITaskTrackingSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
