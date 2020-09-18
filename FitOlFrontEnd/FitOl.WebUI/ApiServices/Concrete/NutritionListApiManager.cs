using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Concrete
{
    public class NutritionListApiManager : INutritionListApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NutritionListApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/NutritionLists/");
        }

        public async Task<List<NutritionListDto>> GetAllAsync()
        {
            var responseMesasage = await _httpClient.GetAsync("");
            if (responseMesasage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<NutritionListDto>>(await responseMesasage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddAsync(NutritionListDto nutritionListDto)
        {
            var jsonData = JsonConvert.SerializeObject(nutritionListDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync("", content);
        }

        //public async Task UpdateAsync(NutritionListDto nutritionListDto)
        //{
        //    var jsonData = JsonConvert.SerializeObject(nutritionListDto);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

        //    await _httpClient.PutAsync($"{nutritionListDto.Id}", content);
        //}

        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.DeleteAsync($"{id}");
        }

        public async Task<NutritionListDto> DetailsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<NutritionListDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task<int> AddFoodForThatAsync(int ogunGun, int nutritionListId)
        {
            var responseMessage = await _httpClient.GetAsync($"AddFoodForThat/{ogunGun}/{nutritionListId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await responseMessage.Content.ReadAsStringAsync());
            }
            return 0;
        }

        public async Task<SelectFoodsAndThatModel> FoodsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"Foods/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SelectFoodsAndThatModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<MealFoodsDto>> NutritionListViewAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"NutritionListViewAsync/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MealFoodsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task FoodsPostAsync(SelectFoodsAndThatModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync($"FoodsPost", content);
        }

        public async Task QuestionsResultAsync(string userName,QuestionModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync($"QuestionsResult/{userName}", content);

        }

    }
}
