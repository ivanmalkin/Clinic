using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Interfaces
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> Prescriptions { get; }

        IEnumerable<Prescription> GetAllPrescriptions();

        void SavePrescription(Prescription prescription);

        Prescription GetPrescriptionById(int prescriptionId);
    }
}
