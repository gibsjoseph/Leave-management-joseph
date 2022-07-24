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
        public int employee_id { get; set; }

        [Column("start_date")]
        [Display(Name = "start_date")]
        public DateTime start_date { get; set; }

        [Column("end_date")]
        [Display(Name = "end_date")]
        public DateTime end_date { get; set; }

        [Column("reason")]
        [Display(Name = "reason")]
        public string reason { get; set; }


    }
}
