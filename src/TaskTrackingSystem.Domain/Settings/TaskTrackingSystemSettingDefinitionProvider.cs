using Volo.Abp.Settings;

namespace TaskTrackingSystem.Settings;

public class TaskTrackingSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TaskTrackingSystemSettings.MySetting1));
    }
}
