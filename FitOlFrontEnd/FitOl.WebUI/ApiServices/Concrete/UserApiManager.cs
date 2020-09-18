using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Concrete
{
    public class UserApiManager : IUserApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpClient _httpClient;
        public UserApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/users/");
        }

        public async Task ProfileEditingAsync(ProfileEditing model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync("ProfileEditing", content);
        }

        public async Task<ProfileInfoViewModel> ProfileInfoAsync(string userName)
        {
            var responseMessage = await _httpClient.GetAsync($"Profile/{userName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProfileInfoViewModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<MealFoodsDto>> UserNutritionListDetailsAsync(string userName)
        {
            var responseMessage = await _httpClient.GetAsync($"UserNutritionListDetails/{userName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MealFoodsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<AreaMovementsDto>> UserSportListDetailsAsync(string userName)
        {
            var responseMessage = await _httpClient.GetAsync($"UserSportListDetails/{userName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<AreaMovementsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


    }
}
