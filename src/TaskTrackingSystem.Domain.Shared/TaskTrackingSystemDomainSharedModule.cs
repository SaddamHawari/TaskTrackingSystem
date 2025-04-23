using TaskTrackingSystem.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.OpenIddict;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.TenantManagement;

namespace TaskTrackingSystem;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule)
    )]
public class TaskTrackingSystemDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        TaskTrackingSystemGlobalFeatureConfigurator.Configure();
        TaskTrackingSystemModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TaskTrackingSystemDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<TaskTrackingSystemResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/TaskTrackingSystem");

            options.DefaultResourceType = typeof(TaskTrackingSystemResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("TaskTrackingSystem", typeof(TaskTrackingSystemResource));
        });
    }
}
