using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EdufaceCms.UI.Models;
using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EdufaceCms.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<UserEntity> _userManager;

        public HomeController(UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["PageSubTitle"] = "Ana Sayfa";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
