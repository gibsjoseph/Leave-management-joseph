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

        [Column("department_id")]
        [Display(Name = "department_id")]
        public string department_id { get; set; }

        [Column("date_of_birth")]
        [Display(Name = "date_of_birth")]
        public string date_of_birth { get; set; }

        [Column("employeeType")]
        [Display(Name = "employeeType")]
        public string employeeType { get; set; }
        
    }
}
