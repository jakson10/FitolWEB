using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static FitOl.WebUI.Enums.AllEnums;

namespace FitOl.WebUI.Models
{
    public class MovementAddModel
    {
        [Required(ErrorMessage = "Hareket İsmi boş geçilemez")]
        [Display(Name = "Hareket İsmi")]
        public string MovementName { get; set; }
        [Required(ErrorMessage = "Hareket Açıklaması boş geçilemez")]
        [Display(Name = "Hareket Açıklaması")]
        public string MovementDescription { get; set; }
        [Required(ErrorMessage = "Hareket Tipi boş geçilemez")]
        [Display(Name = "Hareket Tipi")]
        public EnumMovementType EnumMovementType { get; set; }

        public IFormFile Image { get; set; }
    }
}
