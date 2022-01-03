using Microsoft.AspNetCore.Mvc;

namespace SubParSandwiches.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
