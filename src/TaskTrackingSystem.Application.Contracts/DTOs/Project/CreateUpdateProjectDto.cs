using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DTOs.Project
{
    public class CreateUpdateProjectDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } // Added StartDate property

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } // Added EndDate property

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } // Added Status property
    }
}
