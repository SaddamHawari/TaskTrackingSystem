using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace TaskTrackingSystem.Entity
{
    public class TaskItem : FullAuditedAggregateRoot<Guid>
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public Guid AssignedToUserId { get; set; }

        public ICollection<TimeLog> TimeLogs { get; set; }
    }
}
