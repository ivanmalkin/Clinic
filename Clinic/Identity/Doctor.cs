using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Identity
{
    public class Doctor
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int Experience { get; set; }
    }
}