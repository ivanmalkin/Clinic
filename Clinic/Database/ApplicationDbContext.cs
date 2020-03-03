using Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
