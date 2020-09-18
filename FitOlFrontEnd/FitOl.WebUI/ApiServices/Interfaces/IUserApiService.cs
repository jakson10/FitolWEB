using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task ProfileEditingAsync(ProfileEditing model);

        Task<ProfileInfoViewModel> ProfileInfoAsync(string userName);

        Task<List<MealFoodsDto>> UserNutritionListDetailsAsync(string userName);

        Task<List<AreaMovementsDto>> UserSportListDetailsAsync(string userName);
    }
}
