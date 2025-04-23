using Microsoft.AspNetCore.Builder;
using TaskTrackingSystem;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TaskTrackingSystem.Web.csproj"); 
await builder.RunAbpModuleAsync<TaskTrackingSystemWebTestModule>(applicationName: "TaskTrackingSystem.Web");

public partial class Program
{
}
