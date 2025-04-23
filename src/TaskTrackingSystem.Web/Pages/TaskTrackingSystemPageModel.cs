using TaskTrackingSystem.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TaskTrackingSystem.Web.Pages;

public abstract class TaskTrackingSystemPageModel : AbpPageModel
{
    protected TaskTrackingSystemPageModel()
    {
        LocalizationResourceType = typeof(TaskTrackingSystemResource);
    }
}
