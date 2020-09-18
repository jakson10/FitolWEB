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
    public class SportListApiManager : ISportListApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SportListApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/SportLists/");
        }

        public async Task<List<SportListDto>> GetAllAsync()
        {
            var responseMesasage = await _httpClient.GetAsync("");
            if (responseMesasage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SportListDto>>(await responseMesasage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddAsync(SportListDto sportListDto)
        {
            var jsonData = JsonConvert.SerializeObject(sportListDto);
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

        public async Task<SportListDto> DetailsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"Details/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SportListDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task<int> AddMovementForAreaAsync(int bolgeGun, int sportListId)
        {
            var responseMessage = await _httpClient.GetAsync($"AddMovementForArea/{bolgeGun}/{sportListId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await responseMessage.Content.ReadAsStringAsync());
            }
            return 0;
        }

        public async Task<SelectMovementAndAreaModel> MovementsAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"Movements/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SelectMovementAndAreaModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<AreaMovementsDto>> SportListViewAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"SportListView/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<AreaMovementsDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task MovementsPostAsync(SelectMovementAndAreaModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync($"MovementsPost", content);
        }

        public async Task QuestionsResultAsync(string userName,QuestionSportModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync($"QuestionsSportResult/{userName}", content);

        }
    }
}
