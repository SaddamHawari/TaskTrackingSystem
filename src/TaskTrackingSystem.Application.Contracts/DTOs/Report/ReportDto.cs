﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DTOs.Report
{
    public class ReportDto
    {
        public Guid? ProjectId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TaskId { get; set; }
        public double TotalHours { get; set; }
    }
}
