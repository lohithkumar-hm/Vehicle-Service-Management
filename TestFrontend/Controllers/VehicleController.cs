using Microsoft.AspNetCore.Mvc;
using TestFrontend.Models;
using TestFrontend.Service.Abstraction;

namespace TestFrontend.Controllers
{
    public class VehicleController(IService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllVehiclesAsync();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicle)
        {
            await service.AddVehicleAsync(vehicle);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(string num)
        {
            var data = await service.GetVehicleAsync(num);
            return View(data);
        }


        public async Task<IActionResult> Edit(string num)
        {
            var data = await service.GetVehicleAsync(num);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleViewModel vehicle)
        {
            await service.UpdateVehicleAsync(vehicle);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string num)
        {
            await service.DeleteVehicleAync(num);
            return RedirectToAction("Index");

        }

        
    }
}
