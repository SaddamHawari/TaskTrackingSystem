using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using TaskTrackingSystem.Localization;

namespace TaskTrackingSystem.Web;

[Dependency(ReplaceServices = true)]
public class TaskTrackingSystemBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TaskTrackingSystemResource> _localizer;

    public TaskTrackingSystemBrandingProvider(IStringLocalizer<TaskTrackingSystemResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
