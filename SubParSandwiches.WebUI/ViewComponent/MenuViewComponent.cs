using SubParSandwiches.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        ICatalogService _catalogService;

        public MenuViewComponent(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IViewComponentResult Invoke()
        {
            var items = _catalogService.GetItems();
            return View("~/Views/Shared/_Menu.cshtml", items);
        }
    }
}
