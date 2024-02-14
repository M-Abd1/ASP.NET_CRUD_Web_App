using Bliss_Travels___Tours.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bliss_Travels___Tours.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TouristTravelsContext context;

        public HomeController(ILogger<HomeController> logger, TouristTravelsContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = context.TourManagers.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
