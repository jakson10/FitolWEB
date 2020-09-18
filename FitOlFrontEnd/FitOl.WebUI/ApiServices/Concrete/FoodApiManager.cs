using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Concrete
{
    public class FoodApiManager : IFoodApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FoodApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/foods/");
        }

        public async Task<List<FoodDto>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync(""); //artık adresı yazmana gerke yok baseadressde den gidicek
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<FoodDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<FoodListModel>> GetAllFoodNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllFoodName");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<FoodListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<FoodListModel>> GetMealFoodsAsync(int nutritionListId)
        {
            var responseMessage = await _httpClient.GetAsync($"NutritionListFoodDetails/{nutritionListId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<FoodListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddAsync(FoodAddModel model, string newName)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();

            if (model.Image != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                var bytes = await System.IO.File.ReadAllBytesAsync(path);
                ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteArrayContent, nameof(FoodAddModel.Image), model.Image.FileName);
            }
            formData.Add(new StringContent(model.Name), nameof(FoodAddModel.Name));
            formData.Add(new StringContent(model.CaloriValue.ToString()), nameof(FoodAddModel.CaloriValue));
            formData.Add(new StringContent(model.ProteinValue.ToString()), nameof(FoodAddModel.ProteinValue));
            formData.Add(new StringContent(model.CarbohydrateValue.ToString()), nameof(FoodAddModel.CarbohydrateValue));
            formData.Add(new StringContent(model.OilValue.ToString()), nameof(FoodAddModel.OilValue));
            formData.Add(new StringContent(model.FiberValue.ToString()), nameof(FoodAddModel.FiberValue));
            formData.Add(new StringContent(model.EnumFoodType.ToString()), nameof(FoodAddModel.EnumFoodType));


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync("", formData);
        }

        public async Task UpdateAsync(FoodUpdateModel model, string newName)
        {

            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (model.Image != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                var bytes = await System.IO.File.ReadAllBytesAsync(path);
                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteContent, nameof(FoodUpdateModel.Image), model.Image.FileName);
            }
            formData.Add(new StringContent(model.Id.ToString()), nameof(FoodUpdateModel.Id));
            formData.Add(new StringContent(model.Name), nameof(FoodAddModel.Name));
            formData.Add(new StringContent(model.CaloriValue.ToString()), nameof(FoodAddModel.CaloriValue));
            formData.Add(new StringContent(model.ProteinValue.ToString()), nameof(FoodAddModel.ProteinValue));
            formData.Add(new StringContent(model.CarbohydrateValue.ToString()), nameof(FoodAddModel.CarbohydrateValue));
            formData.Add(new StringContent(model.OilValue.ToString()), nameof(FoodAddModel.OilValue));
            formData.Add(new StringContent(model.FiberValue.ToString()), nameof(FoodAddModel.FiberValue));
            formData.Add(new StringContent(model.EnumFoodType.ToString()), nameof(FoodAddModel.EnumFoodType));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{model.Id}", formData);
        }

        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.DeleteAsync($"{id}");
        }


        public async Task<FoodDto> DetailsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<FoodDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<FoodDto> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"Details/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<FoodDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddToMealFoodAsync(MealFoodModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync("AddToMealFood", content);
        }

        public async Task DeleteToMealFoodAsync(MealFoodModel model)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.DeleteAsync($"DeleteToMealFood?{nameof(MealFoodModel.FKFoodId)}={model.FKFoodId}&{nameof(MealFoodModel.FKThatDayId)}={model.FKThatDayId}");
        }

        public async Task<List<MealFoodsDto>> NutritionListDetailsAsync(int id)
        {
            var responseMessage= await _httpClient.GetAsync($"NutritionListDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MealFoodsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task<List<FoodListModel>> NutritionListThatDayDetailsAsync(int nutritionListId, int thatDayId)
        {
            var responseMessage = await _httpClient.GetAsync($"NutritionListThatDayDetails/{nutritionListId}/{thatDayId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<FoodListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

    }
}
