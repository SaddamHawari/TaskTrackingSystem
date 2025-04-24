using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DTOs.TimeLog
{
    public class CreateUpdateTimeLogDto
    {
        public Guid TaskItemId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LogDate { get; set; }
        public double Hours { get; set; }
        public string Notes { get; set; }
    }
}
