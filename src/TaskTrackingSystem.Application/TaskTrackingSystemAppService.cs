using TaskTrackingSystem.Localization;
using Volo.Abp.Application.Services;

namespace TaskTrackingSystem;

/* Inherit your application services from this class.
 */
public abstract class TaskTrackingSystemAppService : ApplicationService
{
    protected TaskTrackingSystemAppService()
    {
        LocalizationResource = typeof(TaskTrackingSystemResource);
    }
}
