using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.WebUI.Helpers;

namespace SubParSandwiches.WebUI.Areas.User.Controllers
{
    [CustomAuthorise(Role = "User")]
    [Area("User")]
    public class BaseController : Controller
    {

    }
}
