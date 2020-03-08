using System.Linq;
using Clinic.Interfaces;
using Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class AppointmentManageController : Controller
    {
        private IAppointmentRepository repository;

        public AppointmentManageController(IAppointmentRepository repo)
        {
            repository = repo;
        }

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Index() => View(repository.Appointments);

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Edit(int appointmentId) => View(repository.Appointments.FirstOrDefault(p => p.AppointmentId == appointmentId));

        [Authorize(Roles = "Admin, Doctor")]
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAppointment(appointment);
                return RedirectToAction("Index");
            }
            else
            {
                return View(appointment);
            }
        }

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Create() => View("Edit", new Appointment());
    }
}