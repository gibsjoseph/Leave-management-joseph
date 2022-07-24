using Microsoft.AspNetCore.Http;
using Leave_Mgt.Models.Departments;
using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Mgt.Controllers.Departments
{
    public class EmployeeController : Controller
    {
        private IDepartmentRepository departmentRepository;


        public EmployeeController()
        {
            this.departmentRepository = new DepartmentRepository(new Context.LeaveMgtContext());
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = from department in departmentRepository.GetDepartments()
            select department;
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var departments = departmentRepository.GetDepartmentByID(id);
            return View(departments);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View(new Department());
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    departmentRepository.InsertDepartment(department);
                    departmentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to add departments please contact Admin");
            }
            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            Department department = departmentRepository.GetDepartmentByID(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    departmentRepository.UpdateDepartment(department);
                    departmentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to edit departments please contact Admin");
            }
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            
            Department department = departmentRepository.GetDepartmentByID(id);
            return View(department);
           
         }

        // POST: DepartmentController/Delete/5
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletes(int id)
        {
            try
            {
                Department department = departmentRepository.GetDepartmentByID(id);
                departmentRepository.DeleteDepartment(id);
                departmentRepository.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to delete department please contact Admin");
            }
            return RedirectToAction("Index");
        }
    }
}
