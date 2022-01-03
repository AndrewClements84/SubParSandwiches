using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.WebUI.Helpers;

namespace SubParSandwiches.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorise(Role = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {

    }
}
