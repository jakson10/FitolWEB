using FitOl.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Concrete
{
    public class ImageApiManager : IImageApiService
    {
        private readonly HttpClient _httpClient;
        public ImageApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:62188/api/images/");
        }

        public async Task<string> GetFoodImageByIdAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"GetFoodImageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                //bize bir byte dizisi lazım oldugu ıcın readbytearrayasync olarak okucayacağız
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                // bir blog degerini src'nin anlıyabilmesi icin="data:image/jpeg;base64,[byte] boyle bir sey dönmen gerekiyor
                //tipide base64 olucak. 
                //htmlde <image src=tagına bunu adresi basıcak
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }

        public async Task<string> GetMovementImageByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetMovementImageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }

        public async Task<string> GetUserImageByIdAsync(int id, string userName)
        {

            var responseMessage = await _httpClient.GetAsync($"GetUserImageById/{id}/{userName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }
    }
}
