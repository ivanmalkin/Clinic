using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Identity
{
    public class Doctor : ApplicationUser
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string DoctorId { get; set; }

        public int Experience { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}