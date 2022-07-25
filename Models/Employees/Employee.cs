using Leave_Mgt.Models.Departments;
using Leave_Mgt.Models.Leavez;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Leave_Mgt.Models.Employees
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Column("firstName")]
        [Display(Name = "firstName")]
        public string firstName { get; set; }

        [Column("lastName")]
        [Display(Name = "lastName")]
        public string lastName { get; set; }

        [Column("departmentid")]
        [Display(Name = "departmentid")]
        public int departmentid { get; set; }
        public virtual Department department { get; set; }

        [Column("date_of_birth")]
        [Display(Name = "date_of_birth")]
        public DateTime date_of_birth { get; set; }

        [Column("employeeType")]
        [Display(Name = "employeeType")]
        public string employeeType { get; set; }

        public virtual ICollection<Leave> Leaves { get; set; }
        
    }
}
