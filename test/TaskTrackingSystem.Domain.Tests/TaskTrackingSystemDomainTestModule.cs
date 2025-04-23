using Volo.Abp.Modularity;

namespace TaskTrackingSystem;

[DependsOn(
    typeof(TaskTrackingSystemDomainModule),
    typeof(TaskTrackingSystemTestBaseModule)
)]
public class TaskTrackingSystemDomainTestModule : AbpModule
{

}
