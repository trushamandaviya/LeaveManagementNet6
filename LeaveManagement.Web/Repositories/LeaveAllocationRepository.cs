using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, AutoMapper.IConfigurationProvider configurationProvider) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.configurationProvider = configurationProvider;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int leaveAllocationId)
        {
            var allocation = await context.LeaveAllocations
                .Include(q => q.LeaveType)                
                .FirstOrDefaultAsync(q => q.Id == leaveAllocationId);

            if(allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);

            var model = mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = mapper.Map<EmployeeListVM>(employee);

            return model;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            var allocation = await context.LeaveAllocations.FirstOrDefaultAsync(q => q.LeaveTypeId == leaveTypeId && q.EmployeeId == employeeId);

            if (allocation == null)
            {
                return null;
            }
            return allocation;
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var employee = await userManager.FindByIdAsync(employeeId);
            var allocatedLeaves = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveAllocationVM>(configurationProvider)
                .Where(q => q.EmployeeId == employeeId).ToListAsync();

            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.leaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocatedLeaves);

            return employeeAllocationModel;
        }
        public async Task<List<LeaveType>?> GetAllocatedLeaveTypesOfEmployee()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            var leaveTypes = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == user.Id).Select(q => q.LeaveType).ToListAsync();
            
            return leaveTypes;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);
            var period = DateTime.Now.Year;
            List<LeaveAllocation> leaveAllocations = new List<LeaveAllocation>();

            foreach (Employee employee in employees)
            {
                if (await LeaveAllocationExist(employee.Id, leaveTypeId, period))
                    continue;

                leaveAllocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = period
                });
            }
            await AddRangeAsync(leaveAllocations);
        }
        public async Task<bool> LeaveAllocationExist(string employeeId, int leaveTypeId, int period)
        {
            return await context.LeaveAllocations.AnyAsync(s => s.EmployeeId == employeeId && s.LeaveTypeId == leaveTypeId && s.Period == period);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var allocation = await GetAsync(model.Id);
            if (allocation == null)
            {
                return false;
            }
            allocation.Period = model.Period;
            allocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(allocation);

            return true;
        }
    }
}
