using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SubParSandwiches.WebUI.Helpers
{
    public class CustomAuthorise : Attribute, IAuthorizationFilter
    {
        public string Role { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!context.HttpContext.User.IsInRole(Role))
                {
                    context.Result = new RedirectToActionResult("Unuthorised", "Account", new { Area = "" });
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { Area = "" });
            }
        }
    }
}
