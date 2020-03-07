using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Identity
{
    public class Doctor : ApplicationUser
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string DoctorId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int Experience { get; set; }
    }
}