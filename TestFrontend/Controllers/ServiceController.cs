using Microsoft.AspNetCore.Mvc;
using TestFrontend.Models;
using TestFrontend.Service.Abstraction;

namespace TestFrontend.Controllers
{
    public class ServiceController(IService service): Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllserviceAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceViewModel ser)
        {
            await service.AddserviceAsync(ser);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int num)
        {
            var data = await service.GetServiceAsync(num);
            return View(data);
        }


        public async Task<IActionResult> Edit(int num)
        {
            var data = await service.GetServiceAsync(num);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceViewModel ser)
        {
            await service.UpdateServiceAsync(ser);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int num)
        {
            await service.DeleteServiceAync(num);
            return RedirectToAction("Index");

        }
    }
}
