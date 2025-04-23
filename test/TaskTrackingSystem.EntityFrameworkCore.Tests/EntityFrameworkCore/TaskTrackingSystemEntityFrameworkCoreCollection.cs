using Xunit;

namespace TaskTrackingSystem.EntityFrameworkCore;

[CollectionDefinition(TaskTrackingSystemTestConsts.CollectionDefinitionName)]
public class TaskTrackingSystemEntityFrameworkCoreCollection : ICollectionFixture<TaskTrackingSystemEntityFrameworkCoreFixture>
{

}
