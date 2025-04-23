using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace TaskTrackingSystem.Entity
{
    public class TimeLog : FullAuditedAggregateRoot<Guid>
    {
        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        public Guid UserId { get; set; }

        public DateTime LogDate { get; set; }
        public decimal HoursWorked { get; set; }
        public string? Notes { get; set; }
    }
}
