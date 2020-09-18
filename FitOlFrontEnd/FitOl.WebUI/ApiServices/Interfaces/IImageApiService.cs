using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface IImageApiService
    {
        Task<string> GetFoodImageByIdAsync(int id);
        Task<string> GetUserImageByIdAsync(int id, string userName);
        Task<string> GetMovementImageByIdAsync(int id);
    }
}
