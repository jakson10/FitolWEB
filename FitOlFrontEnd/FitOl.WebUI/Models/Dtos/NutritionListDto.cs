using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.WebUI.Enums.AllEnums;

namespace FitOl.WebUI.Models.Dtos
{
    public class NutritionListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalCaloriValue { get; set; }

        public EnumNutritionType EnumNutritionType { get; set; }
        public EnumNutritionKind EnumNutritionKind { get; set; }

        //public virtual ICollection<NutritionDayDto> NutritionDays { get; set; }
        //public virtual ICollection<UserNutritionListsDto> UserNutritionLists { get; set; }
    }
}
