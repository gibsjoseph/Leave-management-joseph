using Leave_Mgt.Models.Departments;
namespace Leave_Mgt.Context.Interfaces
{
    public interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentByID(int departmentId);
        void InsertDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void UpdateDepartment(Department department);
        void Save();
    }
}
