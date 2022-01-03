using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubParSandwiches.Services.Interfaces;
using SubParSandwiches.WebUI.Models;
using System.Diagnostics;

namespace SubParSandwiches.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ICatalogService _catalogService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            var items = _catalogService.GetItems();
            return View(items);
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
