namespace LeaveManagement.Web.Models
{
    public class EmployeeLeaveRequestVM
    {
        public EmployeeLeaveRequestVM()
        {

        }
        public EmployeeLeaveRequestVM(List<LeaveAllocationVM> leaveAllocations, List<LeaveRequestVM> leaveRequests)
        {
            this.leaveAllocations = leaveAllocations;
            this.leaveRequests = leaveRequests;
        }
        public List<LeaveAllocationVM> leaveAllocations { get; set; }
        public List<LeaveRequestVM> leaveRequests { get; set; }
    }
}
