using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager
            ,ILeaveAllocationRepository leaveAllocationRepository) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<bool> ApplyLeaveRequest(LeaveRequestCreateVM modelVM)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, modelVM.LeaveTypeId);
            var daysRequested = (int)(modelVM.EndDate - modelVM.StartDate)?.TotalDays;

            if(allocation == null || daysRequested > allocation?.NumberOfDays)
            {
                return false;
            }
            var leaveRequest = mapper.Map<LeaveRequest>(modelVM);
            leaveRequest.DateCreated = DateTime.Now;
            leaveRequest.DateModified = DateTime.Now;
            leaveRequest.EmployeeId = user.Id;
            leaveRequest.RequestedDate = DateTime.Now;

            await AddAsync(leaveRequest);
            return true;
        }

        public async Task CancelLeave(int id)
        {
            var leaveRequest = await GetAsync(id);
            if(leaveRequest != null)
            {
                leaveRequest.Cancelled = true;
                await UpdateAsync(leaveRequest);

                if(leaveRequest.Approved == true)
                {
                    var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
                    if (allocation != null)
                    {
                        int daysOfLeave = (int)(leaveRequest.EndDate - leaveRequest.StartDate)?.TotalDays;
                        allocation.NumberOfDays += daysOfLeave;
                        await leaveAllocationRepository.UpdateAsync(allocation);
                    }
                }                
            }
        }

        public async Task ChangeLeaveRequestStatus(int Id, bool approved)
        {
            var leaveRequest = await GetAsync(Id);
            leaveRequest.Approved = approved;
            if (approved)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
                if(allocation != null)
                {
                    int daysOfLeave = (int)(leaveRequest.EndDate - leaveRequest.StartDate)?.TotalDays;
                    allocation.NumberOfDays -= daysOfLeave;
                    await leaveAllocationRepository.UpdateAsync(allocation);
                }
            }
            await UpdateAsync(leaveRequest);
        }

        public async Task<LeaveRequestCreateVM> CreateLeaveRequest()
        {
            var leaveTypes = await leaveAllocationRepository.GetAllocatedLeaveTypesOfEmployee();
            
            var model = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(leaveTypes, "Id", "Name")
            };

            return model;
        }

        public async Task<AdminLeaveRequestVM> GetAdminLeaveRequests()
        {
            var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestVM
            {
                TotalLeaveRequests = leaveRequests.Count,
                ApprovedLeaveRequests = leaveRequests.Count(q => q.Approved == true),
                PendingLeaveRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedLeaveRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            foreach(var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.EmployeeId));
            }
            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests.Where(q => q.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? Id)
        {
            var leaveRequest = await context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == Id);

            if(leaveRequest == null)
            {
                return null;
            }

            LeaveRequestVM model = mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.EmployeeId));

            return model;

        }

        public async Task<EmployeeLeaveRequestVM> GetMyLeaveRequestDetail()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).leaveAllocations;
            var requests = mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));
            return new EmployeeLeaveRequestVM(allocations, requests);

        }
    }
}
