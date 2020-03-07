using Clinic.Database;
using Clinic.Interfaces;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Clinic.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ServiceRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Service> Services => _applicationDbContext.Services.ToList();

        public IEnumerable<Service> GetAllServices() => Services.OrderBy(p => p.Name).ToList();

        public IEnumerable<Service> PrefferedServices => _applicationDbContext.Services.Where(p => p.IsPrefferedService).Include(c => c.Category);

        public Service GetServiceById(int serviceId) => _applicationDbContext.Services.FirstOrDefault(d => d.ServiceId == serviceId);

        public void SaveService(Service service)
        {
            if (service != null && service.ServiceId == 0)
            {
                _applicationDbContext.Services.Add(service);
            }
            else
            {
                Service dbEntry = _applicationDbContext.Services.FirstOrDefault(d => d.ServiceId == service.ServiceId);

                if (service != null && dbEntry != null)
                {
                    dbEntry.Name = service.Name;
                    dbEntry.CategoryId = service.CategoryId;
                }
            }

            _applicationDbContext.SaveChanges();
        }

        public Service DeleteService(int serviceId)
        {
            Service dbEntry = _applicationDbContext.Services.FirstOrDefault(d => d.ServiceId == serviceId);

            Service serviceToDelete = _applicationDbContext.Services.Where(d => d.ServiceId == serviceId).SingleOrDefault();

            if (dbEntry != null)
            {
                _applicationDbContext.Services.Remove(dbEntry);
                _applicationDbContext.SaveChanges();
            }

            return dbEntry;
        }
    }
}