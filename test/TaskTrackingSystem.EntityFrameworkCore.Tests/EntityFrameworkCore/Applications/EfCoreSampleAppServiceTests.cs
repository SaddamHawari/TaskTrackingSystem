using TaskTrackingSystem.Samples;
using Xunit;

namespace TaskTrackingSystem.EntityFrameworkCore.Applications;

[Collection(TaskTrackingSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TaskTrackingSystemEntityFrameworkCoreTestModule>
{

}
