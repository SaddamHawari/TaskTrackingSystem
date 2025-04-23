using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace TaskTrackingSystem.Entity
{
    public class Project : FullAuditedAggregateRoot<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; } // Use IdentityUser from Volo.Abp.Identity

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
