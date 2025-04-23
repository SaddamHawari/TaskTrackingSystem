using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace TaskTrackingSystem.Entity
{
    public class Project : FullAuditedAggregateRoot<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid? CreatorId { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
