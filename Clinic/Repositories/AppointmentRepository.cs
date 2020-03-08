using Clinic.Database;
using Clinic.Interfaces;
using Clinic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Clinic.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ShoppingCart _shoppingCart;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentRepository(
            ApplicationDbContext applicationDbContext,
            ShoppingCart shoppingCart,
            IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _shoppingCart = shoppingCart;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Appointment> Appointments => _applicationDbContext.Appointments.ToList();

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return Appointments.OrderBy(p => p.AppointmentId).ToList();
        }

        public void CreateAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                decimal appointmentTotalSum = 0;
                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    appointmentTotalSum += shoppingCartItem.Amount * shoppingCartItem.Service.Price;
                }

                appointment.AppointmentPlaced = DateTime.Now;
                appointment.TotalSum = appointmentTotalSum;
                appointment.PatientId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                appointment.DiagnosisId = 3;

                _applicationDbContext.Appointments.Add(appointment);
                _applicationDbContext.SaveChanges();

                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    var appointmentLine = new AppointmentLine()
                    {
                        Amount = shoppingCartItem.Amount,
                        ServiceId = shoppingCartItem.Service.ServiceId,
                        AppointmentId = appointment.AppointmentId,
                        Price = shoppingCartItem.Service.Price
                    };

                    _applicationDbContext.AppointmentLines.Add(appointmentLine);
                }

                _applicationDbContext.SaveChanges();
            }
        }

        public void SaveAppointment(Appointment appointment)
        {
            if (appointment != null && appointment.AppointmentId == 0)
            {
                _applicationDbContext.Appointments.Add(appointment);
            }
            else
            {
                Appointment dbEntry = _applicationDbContext.Appointments.FirstOrDefault(d => d.AppointmentId == appointment.AppointmentId);

                if (appointment != null && dbEntry != null)
                {
                    dbEntry.Diagnosis = appointment.Diagnosis;
                }
            }

            _applicationDbContext.SaveChanges();
        }
    }
}