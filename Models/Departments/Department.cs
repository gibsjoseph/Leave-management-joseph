using Leave_Mgt.Models.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Leave_Mgt.Models.Departments
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        
        [Column("department")]
        [Display(Name = "Department")]
        public string department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
