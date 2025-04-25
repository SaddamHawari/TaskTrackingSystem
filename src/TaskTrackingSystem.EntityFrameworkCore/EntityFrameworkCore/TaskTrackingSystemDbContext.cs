using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using TaskTrackingSystem.Entity;

namespace TaskTrackingSystem.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class TaskTrackingSystemDbContext :
    AbpDbContext<TaskTrackingSystemDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public TaskTrackingSystemDbContext(DbContextOptions<TaskTrackingSystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */
        // Configure the TaskTrackingSystem module entities
        // Configure Project entity
        builder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects"); // Table name
            entity.HasKey(p => p.Id); // Primary key

            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(128); // Name column configuration

            entity.Property(p => p.Description)
                  .HasColumnType("text"); // Description column configuration

            entity.Property(p => p.CreatorId)
                  .IsRequired(false); // CreatorId column configuration (nullable)

            entity.Property(p => p.StartDate)
                  .HasColumnType("timestamp without time zone"); // StartDate column configuration

            entity.Property(p => p.EndDate)
                  .HasColumnType("timestamp without time zone"); // EndDate column configuration

            entity.Property(p => p.Status)
                  .HasMaxLength(50); // Status column configuration
        });

        // Configure TaskItem entity
        builder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("TaskItems"); // Table name
            entity.HasKey(t => t.Id); // Primary key

            entity.Property(t => t.Title)
                  .IsRequired()
                  .HasMaxLength(128); // Title column configuration

            entity.Property(t => t.Description)
                  .HasMaxLength(500); // Description column configuration

            entity.Property(t => t.DueDate)
                  .HasColumnType("timestamp without time zone"); // DueDate column configuration

            entity.Property(t => t.Status)
                  .HasConversion<string>() // Store enum as string
                  .IsRequired();

            entity.Property(t => t.Priority)
                  .HasConversion<string>() // Store enum as string
                  .IsRequired();

            entity.HasOne(t => t.Project)
                  .WithMany()
                  .HasForeignKey(t => t.ProjectId)
                  .OnDelete(DeleteBehavior.Restrict); // Foreign key to Project

            entity.HasOne<IdentityUser>()
                  .WithMany()
                  .HasForeignKey(t => t.AssignedToUserId)
                  .OnDelete(DeleteBehavior.Restrict); // Foreign key to User
        });

        // Configure TimeLog entity
        builder.Entity<TimeLog>(entity =>
        {
            entity.ToTable("TimeLogs"); // Table name
            entity.HasKey(t => t.Id); // Primary key

            entity.Property(t => t.LogDate)
                  .HasColumnType("timestamp without time zone")
                  .IsRequired(); // LogDate column configuration

            entity.Property(t => t.HoursWorked)
                  .IsRequired(); // HoursWorked column configuration

            entity.Property(t => t.Notes)
                  .HasMaxLength(1000); // Notes column configuration

            entity.HasOne(t => t.TaskItem)
                  .WithMany(ti => ti.TimeLogs)
                  .HasForeignKey(t => t.TaskItemId)
                  .OnDelete(DeleteBehavior.Restrict); // Foreign key to TaskItem

            entity.HasOne<IdentityUser>()
                  .WithMany()
                  .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.Restrict); // Foreign key to User
        });

    }
}
