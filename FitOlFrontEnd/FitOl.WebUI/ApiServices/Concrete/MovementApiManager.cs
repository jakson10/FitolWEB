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
    public class MovementApiManager : IMovementApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovementApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/movements/");
        }

        public async Task<List<MovementDto>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MovementDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<MovementListModel>> GetAllMovementNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllMovementName");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MovementListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<MovementListModel>> GetAreaMovementsAsync(int sportListId)
        {
            var responseMessage = await _httpClient.GetAsync($"SportListMovementDetails/{sportListId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MovementListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddAsync(MovementAddModel model, string newName)
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
            formData.Add(new StringContent(model.MovementName), nameof(MovementAddModel.MovementName));
            formData.Add(new StringContent(model.MovementDescription), nameof(MovementAddModel.MovementDescription));
            formData.Add(new StringContent(model.EnumMovementType.ToString()), nameof(MovementAddModel.EnumMovementType));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync("", formData);
        }

        public async Task UpdateAsync(MovementUpdateModel model, string newName)
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
            formData.Add(new StringContent(model.Id.ToString()), nameof(MovementUpdateModel.Id));
            formData.Add(new StringContent(model.MovementName), nameof(MovementUpdateModel.MovementName));
            formData.Add(new StringContent(model.MovementDescription), nameof(MovementUpdateModel.MovementDescription));
            formData.Add(new StringContent(model.EnumMovementType.ToString()), nameof(MovementUpdateModel.EnumMovementType));


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{model.Id}", formData);
        }

        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.DeleteAsync($"{id}");
        }


        public async Task<MovementDto> DetailsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<MovementDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<MovementDto> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"Details/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<MovementDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddToAreaMovementAsync(AreaMovementModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync("AddToAreaMovement", content);
        }

        public async Task DeleteToAreaMovementAsync(AreaMovementModel model)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.DeleteAsync($"DeleteToAreaMovement?{nameof(AreaMovementModel.FKMovementId)}={model.FKMovementId}&{nameof(AreaMovementModel.FKAreaId)}={model.FKAreaId}");
        }

        public async Task<List<AreaMovementsDto>> SportListDetailsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"SportListDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<AreaMovementsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task<List<MovementListModel>> SportistAreaMovementDetailsAsync(int sportListId, int areaId)
        {
            var responseMessage = await _httpClient.GetAsync($"SportListAreaMovementDetails/{sportListId}/{areaId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<MovementListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }



    }
}