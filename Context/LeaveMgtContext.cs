
using Leave_Mgt.Models.Departments;
using Leave_Mgt.Models.Leavez;
using Leave_Mgt.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace Leave_Mgt.Context
{
    public class LeaveMgtContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OAEIFA2; Database=leaveMgt; User Id=sa; Password=P@ssw0rd; Trusted_Connection=false; MultipleActiveResultSets=true;",
                options => options.EnableRetryOnFailure());
        }

        public DbSet<Department> lDepartments { get; set; }
        public DbSet<Employee> lEmployees { get; set; }
        public DbSet<Leave> lLeaves { get; set; }
    }
}
