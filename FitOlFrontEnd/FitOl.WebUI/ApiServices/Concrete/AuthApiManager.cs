using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Enums;
using FitOl.WebUI.Enums.UserInfo;
using FitOl.WebUI.Extensions;
using FitOl.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Concrete
{
    public class AuthApiManager : IAuthApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        public AuthApiManager(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/Auth/");
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =  await _httpClient.PostAsync("", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var userInformation = JsonConvert.DeserializeObject<UserInformation>(await responseMessage.Content.ReadAsStringAsync());
                _httpContextAccessor.HttpContext.Session.SetString("token", userInformation.Token);
                _httpContextAccessor.HttpContext.Session.SetObject("user", userInformation.appUser);
                return true;
            }
            return false;
        }

        public async Task<int> LogoutAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"Logout");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await responseMessage.Content.ReadAsStringAsync());
            }
            return 1;
        }


        public async Task<AppUser> RegisterAsync(RegisterModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync($"RegisterPost", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AppUser>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

    }
}
