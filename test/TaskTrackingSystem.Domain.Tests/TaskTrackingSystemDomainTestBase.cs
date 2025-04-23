using Volo.Abp.Modularity;

namespace TaskTrackingSystem;

/* Inherit from this class for your domain layer tests. */
public abstract class TaskTrackingSystemDomainTestBase<TStartupModule> : TaskTrackingSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
