using Microsoft.AspNetCore.Http;
using Leave_Mgt.Models.Leavez;
using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Mgt.Controllers.leaves
{
    public class LeaveController : Controller
    {
        private ILeaveRepository leaveRepository;


        public LeaveController()
        {
            this.leaveRepository = new LeaveRepository(new Context.LeaveMgtContext());
        }

        // GET: leaveController
        public ActionResult Index()
        {
            var leaves = from leave in leaveRepository.GetLeaves()
            select leave;
            return View(leaves);
        }

        // GET: leaveController/Details/5
        public ActionResult Details(int id)
        {
            var leaves = leaveRepository.GetLeaveByID(id);
            return View(leaves);
        }

        // GET: leaveController/Create
        public ActionResult Create()
        {
            return View(new Leave());
        }

        // POST: leaveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Leave leave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    leaveRepository.InsertLeave(leave);
                    leaveRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to add leaves please contact Admin");
            }
            return View(leave);
        }

        // GET: leaveController/Edit/5
        public ActionResult Edit(int id)
        {
            Leave leave = leaveRepository.GetLeaveByID(id);
            return View(leave);
        }

        // POST: leaveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Leave leave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    leaveRepository.UpdateLeave(leave);
                    leaveRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to edit leaves please contact Admin");
            }
            return View(leave);
        }

        // GET: leaveController/Delete/5
        public ActionResult Delete(int id)
        {
            
            Leave leave = leaveRepository.GetLeaveByID(id);
            return View(leave);
           
         }

        // POST: leaveController/Delete/5
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletes(int id)
        {
            try
            {
                Leave leave = leaveRepository.GetLeaveByID(id);
                leaveRepository.DeleteLeave(id);
                leaveRepository.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to delete leave please contact Admin");
            }
            return RedirectToAction("Index");
        }
    }
}
