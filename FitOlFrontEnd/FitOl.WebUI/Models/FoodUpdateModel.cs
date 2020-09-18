using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static FitOl.WebUI.Enums.AllEnums;

namespace FitOl.WebUI.Models
{
    public class FoodUpdateModel
    {
   
        public int Id { get; set; }

        [Display(Name = "Besin İsmi")]
        [Required(ErrorMessage = "Besin ismi boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Kalori Değeri")]
        [Required(ErrorMessage = "Kalori değeri boş geçilemez")]
        public double CaloriValue { get; set; }

        [Display(Name = "Protein Değeri")]
        [Required(ErrorMessage = "Protein değeri boş geçilemez")]
        public double ProteinValue { get; set; }

        [Display(Name = "Karbonhidrat Değeri")]
        [Required(ErrorMessage = "Karbonhidrat değeri boş geçilemez")]
        public double CarbohydrateValue { get; set; }

        [Display(Name = "Yağ Değeri")]
        [Required(ErrorMessage = "Yağ değeri boş geçilemez")]
        public double OilValue { get; set; }

        [Display(Name = "Lif Değeri")]
        [Required(ErrorMessage = "Lif değeri boş geçilemez")]
        public double FiberValue { get; set; }

        [Display(Name = "Besin Türü")]
        [Required(ErrorMessage = "Besin Türü boş geçilemez")]
        public EnumFoodType EnumFoodType { get; set; }

        public IFormFile Image { get; set; }
    }
}
