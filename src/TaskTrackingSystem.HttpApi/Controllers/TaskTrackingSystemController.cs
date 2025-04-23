using TaskTrackingSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TaskTrackingSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TaskTrackingSystemController : AbpControllerBase
{
    protected TaskTrackingSystemController()
    {
        LocalizationResource = typeof(TaskTrackingSystemResource);
    }
}
