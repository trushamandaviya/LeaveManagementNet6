#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using LeaveManagement.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly ILogger<LeaveRequestsController> logger;

        public LeaveRequestsController(ApplicationDbContext context,ILeaveRequestRepository leaveRequestRepository, ILogger<LeaveRequestsController> logger)
        {
            _context = context;
            this.leaveRequestRepository = leaveRequestRepository;
            this.logger = logger;
        }

        // GET: LeaveRequests
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var model = await leaveRequestRepository.GetAdminLeaveRequests();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        
        public async Task<ActionResult> Details(int? id)
        {
            var model = await leaveRequestRepository.GetLeaveRequestAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        
        public async Task<ActionResult> ChangeLeaveRequestStatus(int Id, bool approved)
        {
            try
            {
                await leaveRequestRepository.ChangeLeaveRequestStatus(Id, approved);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> MyLeaves()
        {
            EmployeeLeaveRequestVM model = null;
            try
            {
                model = await leaveRequestRepository.GetMyLeaveRequestDetail();
                return View(model);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
            }
            model = new EmployeeLeaveRequestVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cancel(int id)
        {
            try
            {
                await leaveRequestRepository.CancelLeave(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
            }
            return RedirectToAction(nameof(MyLeaves));
        }

        // GET: LeaveRequests/Create
        public async Task<ActionResult> Create()
        {
            var model = new LeaveRequestCreateVM();
            try
            {
                logger.LogError("Error while creating leave");
                model = await leaveRequestRepository.CreateLeaveRequest();                  
            }
            catch (Exception ex)
            {
                logger.LogError("Error while creating leave");
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
            }
            
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool success = await leaveRequestRepository.ApplyLeaveRequest(leaveRequestVM);
                    if(success)
                        return RedirectToAction(nameof(MyLeaves));
                    else
                        ModelState.AddModelError(string.Empty, "Invalid request");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, please try again later.");
            }
            
            leaveRequestVM.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", leaveRequestVM.LeaveTypeId);
            return View(leaveRequestVM);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeId,EmployeeId,Approved,Cancelled,Id,DateCreated,DateModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
