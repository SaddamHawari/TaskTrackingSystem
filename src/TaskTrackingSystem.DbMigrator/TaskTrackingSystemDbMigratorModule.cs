using TaskTrackingSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TaskTrackingSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TaskTrackingSystemEntityFrameworkCoreModule),
    typeof(TaskTrackingSystemApplicationContractsModule)
)]
public class TaskTrackingSystemDbMigratorModule : AbpModule
{
}
