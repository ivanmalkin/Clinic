using System;

namespace Clinic.Identity
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Patient : ApplicationUser
    {
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
