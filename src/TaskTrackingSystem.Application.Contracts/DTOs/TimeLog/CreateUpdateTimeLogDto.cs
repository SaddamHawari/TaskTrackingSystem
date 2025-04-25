using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DTOs.TimeLog
{
    public class CreateUpdateTimeLogDto
    {
        [Required(ErrorMessage = "TaskItemId is required.")]
        public Guid TaskItemId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "LogDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [PastOrTodayDate(ErrorMessage = "LogDate cannot be in the future.")]
        public DateTime LogDate { get; set; }

        [Required(ErrorMessage = "Hours are required.")]
        [Range(0.1, 24, ErrorMessage = "Hours must be between 0.1 and 24.")]
        public double Hours { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters.")]
        public string Notes { get; set; }
    }

    // Custom validation attribute to ensure the date is not in the future
    public class PastOrTodayDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime && dateTime > DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "The date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}
