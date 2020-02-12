using Microsoft.AspNetCore.Mvc;

namespace EdufaceCms.UI.Controllers
{
    public class ViewComponentController : Controller
    {
        public IActionResult GetUserRoles(string id)
        {
            return ViewComponent("UserRoles", new { id });
        }
    }
}