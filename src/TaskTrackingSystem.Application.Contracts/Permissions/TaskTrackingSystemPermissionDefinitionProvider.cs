using TaskTrackingSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace TaskTrackingSystem.Permissions;

public class TaskTrackingSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TaskTrackingSystemPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(TaskTrackingSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TaskTrackingSystemResource>(name);
    }
}
