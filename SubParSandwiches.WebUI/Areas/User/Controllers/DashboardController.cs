using Microsoft.AspNetCore.Mvc;

namespace SubParSandwiches.WebUI.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
