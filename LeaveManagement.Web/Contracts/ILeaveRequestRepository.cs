using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> ApplyLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestVM> GetMyLeaveRequestDetail();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task<AdminLeaveRequestVM> GetAdminLeaveRequests();
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id);
        Task ChangeLeaveRequestStatus(int Id, bool approved);
        Task CancelLeave(int id);
        Task<LeaveRequestCreateVM> CreateLeaveRequest();
    }
}
