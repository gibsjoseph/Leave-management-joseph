using Leave_Mgt.Models.Employees;
namespace Leave_Mgt.Context.Interfaces
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
