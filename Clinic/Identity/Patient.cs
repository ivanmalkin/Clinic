using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Identity
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Patient
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}