using Microsoft.AspNetCore.Http;
using Leave_Mgt.Models.Employees;
using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Mgt.Controllers.Employees
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;


        public EmployeeController()
        {
            this.employeeRepository = new EmployeeRepository(new Context.LeaveMgtContext());
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var employe = from employee in employeeRepository.GetEmployees()
            select employee;
            return View(employe);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var employe = employeeRepository.GetEmployeeByID(id);
            return View(employe);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.InsertEmployee(employee);
                    employeeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to add departments please contact Admin");
            }
            return View(employee);
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = employeeRepository.GetEmployeeByID(id);
            return View(employee);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.UpdateEmployee(employee);
                    employeeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to edit departments please contact Admin");
            }
            return View(employee);
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            
            Employee employee = employeeRepository.GetEmployeeByID(id);
            return View(employee);
           
         }

        // POST: DepartmentController/Delete/5
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletes(int id)
        {
            try
            {
                Employee employee = employeeRepository.GetEmployeeByID(id);
                employeeRepository.DeleteEmployee(id);
                employeeRepository.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to delete department please contact Admin");
            }
            return RedirectToAction("Index");
        }
    }
}
