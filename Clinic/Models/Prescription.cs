using System;

namespace Clinic.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Description { get; set; }
    }
}