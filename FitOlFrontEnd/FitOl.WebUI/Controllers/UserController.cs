using System.Threading.Tasks;
using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Extensions;
using FitOl.WebUI.Filters;
using FitOl.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebUI.Controllers
{
    [Authorize(Roles = RoleConstants.AdminAndUser)]
    [JwtAuthorize]
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;
        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var profileInfo = await _userApiService.ProfileInfoAsync(User.Identity.Name);
            return View(profileInfo);
        }

        public IActionResult ProfileEditing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEditing(ProfileEditing profileEditing)
        {
            if (profileEditing.UserName == null)
            {
                profileEditing.UserName = User.Identity.Name;
                await _userApiService.ProfileEditingAsync(profileEditing);
                return RedirectToAction("Profile", "User");
            }

            return View(profileEditing);
        }

        public async Task<IActionResult> SportListDetails()
        {
            var userSportList = await _userApiService.UserSportListDetailsAsync(User.Identity.Name);
            if (userSportList != null)
            {
                return View(userSportList);
            }
            else
            {
                return RedirectToAction("Calculator", "Home");
            }
        }

        public async Task<IActionResult> NutritionListDetails()
        {
            var userNutritionList = await _userApiService.UserNutritionListDetailsAsync(User.Identity.Name);
            if (userNutritionList != null)
            {
                return View(userNutritionList);
            }
            else
            {
                return RedirectToAction("Calculator", "Home");
            }
        }
    }
}
