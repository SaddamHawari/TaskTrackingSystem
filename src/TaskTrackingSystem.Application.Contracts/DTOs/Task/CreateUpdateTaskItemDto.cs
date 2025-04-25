using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DTOs.Task
{
    public class CreateUpdateTaskItemDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ProjectId is required.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "AssignedUserId is required.")]
        public Guid AssignedUserId { get; set; }

        [Required(ErrorMessage = "DueDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [FutureDate(ErrorMessage = "DueDate must be in the future.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(New|InProgress|Completed|OnHold)$", ErrorMessage = "Invalid status value.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [RegularExpression("^(Low|Medium|High|Critical)$", ErrorMessage = "Invalid priority value.")]
        public string Priority { get; set; }
    }

    // Custom validation attribute for future dates
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime && dateTime <= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}
