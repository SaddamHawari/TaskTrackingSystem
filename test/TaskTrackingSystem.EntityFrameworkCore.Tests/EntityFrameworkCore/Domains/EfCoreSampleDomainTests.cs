using TaskTrackingSystem.Samples;
using Xunit;

namespace TaskTrackingSystem.EntityFrameworkCore.Domains;

[Collection(TaskTrackingSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TaskTrackingSystemEntityFrameworkCoreTestModule>
{

}
