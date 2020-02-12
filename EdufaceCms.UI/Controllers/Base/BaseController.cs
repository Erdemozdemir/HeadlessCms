using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace EdufaceCms.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        public string PageSubTitle { get; set; }
        public string UserName { get; set; }
        public Task<UserEntity> CurrentUser
        {
            get { return GetCurrentUser(); }
        }

        public BaseController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<UserEntity> GetCurrentUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(currentUser);
            return user;
        }

        public override async void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewData["PageSubTitle"] = PageSubTitle;

            var user = await CurrentUser;
            if (user != null)
                ViewData["Username"] = user.UserName;

        }
    }
}