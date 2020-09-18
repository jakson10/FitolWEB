using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface IFoodApiService
    {
        Task<List<FoodDto>> GetAllAsync();
        Task<List<FoodListModel>> GetAllFoodNameAsync();
        Task<List<FoodListModel>> GetMealFoodsAsync(int nutritionListId);
        Task AddAsync(FoodAddModel model, string newName);
        Task UpdateAsync(FoodUpdateModel model, string newName);
        Task DeleteAsync(int id);
        Task<FoodDto> DetailsAsync(int id);
        Task<FoodDto> GetByIdAsync(int id);
        Task AddToMealFoodAsync(MealFoodModel model);
        Task DeleteToMealFoodAsync(MealFoodModel model);
        Task<List<MealFoodsDto>> NutritionListDetailsAsync(int id);

        Task<List<FoodListModel>> NutritionListThatDayDetailsAsync(int nutritionListId, int thatDayId);

        //Task<List<FoodListModel>> NutritionListThatDayDetailsAsync(int nutritionListId, int gunId, int ogunId);
    }
}
