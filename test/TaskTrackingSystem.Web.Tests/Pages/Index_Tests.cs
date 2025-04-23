using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TaskTrackingSystem.Pages;

[Collection(TaskTrackingSystemTestConsts.CollectionDefinitionName)]
public class Index_Tests : TaskTrackingSystemWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
