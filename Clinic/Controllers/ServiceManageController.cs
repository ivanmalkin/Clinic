using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Clinic.Interfaces;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class ServiceManageController : Controller
    {
        private IServiceRepository repository;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceManageController(IServiceRepository repo)
        {
            repository = repo;
        }

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Index() => View(repository.Services);

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Edit(int serviceId) => View(repository.Services.FirstOrDefault(p => p.ServiceId == serviceId));

        [Authorize(Roles = "Admin, Doctor")]
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                repository.SaveService(service);
                log.Info($"Услуга {service.Name} отредактирована или создана.");
                TempData["message"] = $"{service.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(service);
            }
        }

        [Authorize(Roles = "Admin, Doctor")]
        public ViewResult Create() => View("Edit", new Service());

        [Authorize(Roles = "Admin, Doctor")]
        [HttpPost]
        public IActionResult Delete(int serviceId)
        {
            Service deletedService = repository.DeleteService(serviceId);
            log.Info($"Услуга {deletedService} удалена.");
            if (deletedService != null)
            {
                TempData["message"] = $"{deletedService.Name} была удалена";
            }
            return RedirectToAction("Index");
        }
    }
}
