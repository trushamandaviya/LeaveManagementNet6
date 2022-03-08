namespace LeaveManagement.Web.Models
{
    public class AdminLeaveRequestVM
    {
        public int TotalLeaveRequests { get; set; }
        public int ApprovedLeaveRequests { get; set; }
        public int RejectedLeaveRequests { get; set; }
        public int PendingLeaveRequests { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
