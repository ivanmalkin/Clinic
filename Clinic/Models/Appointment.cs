using Clinic.Identity;
using System;
using System.Collections.Generic;

namespace Clinic.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public List<AppointmentLine> AppointmentLines { get; set; }

        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public int DiagnosisId { get; set; }

        public decimal TotalSum { get; set; }
        public DateTime AppointmentPlaced { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}