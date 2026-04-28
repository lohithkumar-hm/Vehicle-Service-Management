using Microsoft.AspNetCore.Mvc;
using TestFrontend.Service.Abstraction;

namespace TestFrontend.Controllers
{
    public class ServiceReportController(IService service) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var data = await service.GetServiceReport();
            return View(data);
        }
    }
}
