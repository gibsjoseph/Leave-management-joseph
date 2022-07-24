using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Leave_Mgt.Models.Leavez
{
    public class Leave
    {
        [Key]
        public int id { get; set; }

        [Column("employee_id")]
        [Display(Name = "employee_id")]
        public string employee_id { get; set; }

        [Column("startDate")]
        [Display(Name = "startDate")]
        public string startDate { get; set; }

        [Column("endDate")]
        [Display(Name = "endDate")]
        public string endDate { get; set; }

        [Column("reason")]
        [Display(Name = "reason")]
        public string reason { get; set; }


    }
}
