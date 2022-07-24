using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context;
using Leave_Mgt.Models.Departments;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Leave_Mgt.Context.Repositories
{ 
    public class DepartmentRepository : IDepartmentRepository
    {
        private LeaveMgtContext _context;
        public DepartmentRepository(LeaveMgtContext leaveMgtContext)
        {
            this._context = leaveMgtContext;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _context.lDepartments .ToList();
        }
        public Department GetDepartmentByID(int id)
        {
            return _context.lDepartments.Find(id);
        }
        public void InsertDepartment(Department department)
        {
            _context.lDepartments.Add(department);
        }
        public void DeleteDepartment(int departmentID)
        {
            Department department = _context.lDepartments.Find(departmentID);
            _context.lDepartments.Remove(department);
        }
        public void UpdateDepartment(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
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

