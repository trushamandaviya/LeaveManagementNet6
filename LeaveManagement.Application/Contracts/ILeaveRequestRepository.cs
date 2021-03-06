using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Contracts
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
