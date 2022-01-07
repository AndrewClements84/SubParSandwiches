using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.WebUI.Helpers;
using SubParSandwiches.WebUI.Interfaces;

namespace SubParSandwiches.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorise(Role = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {

    }
}
