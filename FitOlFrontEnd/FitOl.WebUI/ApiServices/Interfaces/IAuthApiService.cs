using FitOl.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> LoginAsync(LoginModel model);

        Task<int> LogoutAsync();

        Task<AppUser> RegisterAsync(RegisterModel model);
    }
}
