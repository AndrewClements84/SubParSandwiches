using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.Entities;
using SubParSandwiches.WebUI.Interfaces;

namespace SubParSandwiches.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser
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
