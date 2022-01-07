using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.WebUI.Helpers;
using SubParSandwiches.WebUI.Interfaces;

namespace SubParSandwiches.WebUI.Areas.User.Controllers
{
    [CustomAuthorise(Role = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
        public Entities.User CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }

        IUserAccessor _userAccessor;
        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }
    }
}
