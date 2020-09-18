using FitOl.WebUI.Models.Dtos;
using System.Collections.Generic;

namespace FitOl.WebUI.Models
{
    public class SelectFoodsAndThatModel
    {
        public List<FoodDto> allFoods { get; set; }
        public int thatId { get; set; }
        public string[] selectedFoodIdArray { get; set; }
    }
}
