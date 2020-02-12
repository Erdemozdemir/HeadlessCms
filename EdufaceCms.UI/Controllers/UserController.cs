using System.Threading.Tasks;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EdufaceCms.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly UserManager<UserEntity> _userManager;
        private SignInManager<UserEntity> _signInManager;
        public UserController(UserManager<UserEntity> userManager, IPasswordHasher<UserEntity> passwordHasher, SignInManager<UserEntity> signInManager) : base(userManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            var user = await CurrentUser;
            var model = new SettingModel
            {
                Username = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SettingModel settingModel)
        {
            if (!ModelState.IsValid) return View(settingModel);

            var user = await CurrentUser;
            var hashPass = _passwordHasher.HashPassword(user, settingModel.Password);
            user.PasswordHash = hashPass;
            await _userManager.UpdateAsync(user);

            return View(settingModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}