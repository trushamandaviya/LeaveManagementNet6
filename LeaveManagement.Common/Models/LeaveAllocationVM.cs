using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Number Of Days")]
        [Range(1,50, ErrorMessage ="Please enter valid number of days")]
        public int NumberOfDays { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }

        [Required]
        public int Period { get; set; }
    }
}
