using Clinic.Models;

namespace Clinic.Interfaces
{
    public interface IAppointmentRepository
    {
        void CreateAppointment(Appointment appointment);
    }
}
