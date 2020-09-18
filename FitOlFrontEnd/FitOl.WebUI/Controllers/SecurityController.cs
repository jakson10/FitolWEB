using System.Security.Claims;
using System.Threading.Tasks;
using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Enums;
using FitOl.WebUI.Enums.UserInfo;
using FitOl.WebUI.Extensions;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IAuthApiService _authApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private SignInManager<AppUser> _signInManager;



        public SecurityController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
            //_signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (await _authApiService.LoginAsync(model))
            {
                var user = _httpContextAccessor.HttpContext.Session.GetObject<AppUserDtoss>("user");
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                if (user.IsAdmin)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                }
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction("Calculator", "Home");
            }
            return View(model);
        }

        public ActionResult ObeyMyOrder()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Food");
            }
            return RedirectToAction("Index", "Food");
        }


        public ViewResult Index() => View(User?.Claims);


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Calculator", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await _authApiService.RegisterAsync(model);
            if (user != null)
            {
                return RedirectToAction("Login", "Security");
            }
            return View(model);
        }

        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}



        //public IActionResult ConfirmEmail(string userId, string code)
        //{
        //    return View();
        //}

        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(string email)
        //{
        //    return View();
        //}

        //public IActionResult ForgotPasswordEmailSend()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> ResetPassword()
        //{
        //    return View();
        //}


        //public IActionResult ResetPasswordConfirm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetPasswordPost(ResetPasswordModel model)
        //{
        //    return View();

        //}



    }
}
