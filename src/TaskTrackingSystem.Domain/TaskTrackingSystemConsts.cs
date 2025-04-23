using Volo.Abp.Identity;

namespace TaskTrackingSystem;

public static class TaskTrackingSystemConsts
{
    public const string  DbTablePrefix = "App";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
