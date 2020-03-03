using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Identity
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Patient : ApplicationUser
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string PatientId { get; set; }

        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
