using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface INutritionListApiService
    {
        Task<List<NutritionListDto>> GetAllAsync();
        Task AddAsync(NutritionListDto nutritionListDto);
        Task DeleteAsync(int id);
        Task<NutritionListDto> DetailsAsync(int id);
        Task<int> AddFoodForThatAsync(int ogunGun, int nutritionListId);
        Task<SelectFoodsAndThatModel> FoodsAsync(int id);
        Task<List<MealFoodsDto>> NutritionListViewAsync(int id);
        Task QuestionsResultAsync(string userName,QuestionModel model);
        Task FoodsPostAsync(SelectFoodsAndThatModel model);

    }
}
