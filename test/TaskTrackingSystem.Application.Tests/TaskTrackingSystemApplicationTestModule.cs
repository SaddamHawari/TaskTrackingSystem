using Volo.Abp.Modularity;

namespace TaskTrackingSystem;

[DependsOn(
    typeof(TaskTrackingSystemApplicationModule),
    typeof(TaskTrackingSystemDomainTestModule)
)]
public class TaskTrackingSystemApplicationTestModule : AbpModule
{

}
