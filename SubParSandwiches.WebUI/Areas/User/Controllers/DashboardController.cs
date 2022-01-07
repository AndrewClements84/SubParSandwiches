using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.WebUI.Interfaces;

namespace SubParSandwiches.WebUI.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IUserAccessor userAccessor) 
            : base(userAccessor)
        {
                
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
