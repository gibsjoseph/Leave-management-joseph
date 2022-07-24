using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context;
using Leave_Mgt.Models.Employees;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Leave_Mgt.Context.Repositories
{ 
    public class EmployeeRepository : IEmployeeRepository
    {
        private LeaveMgtContext _context;
        public EmployeeRepository(LeaveMgtContext leaveMgtContext)
        {
            this._context = leaveMgtContext;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.lEmployees .ToList();
        }
        public Employee GetEmployeeByID(int id)
        {
            return _context.lEmployees.Find(id);
        }
        public void InsertEmployee(Employee employee)
        {
            _context.lEmployees.Add(employee);
        }
        public void DeleteEmployee(int employeeID)
        {
            Employee employee = _context.lEmployees.Find(employeeID);
            _context.lEmployees.Remove(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

