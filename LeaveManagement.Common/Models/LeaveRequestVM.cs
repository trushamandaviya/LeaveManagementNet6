﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [Display(Name ="Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }
        public DateTime RequestedDate { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string? EmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }
    }
}
