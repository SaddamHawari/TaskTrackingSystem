using Volo.Abp.Modularity;

namespace TaskTrackingSystem;

public abstract class TaskTrackingSystemApplicationTestBase<TStartupModule> : TaskTrackingSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
