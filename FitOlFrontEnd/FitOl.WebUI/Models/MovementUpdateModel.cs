using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static FitOl.WebUI.Enums.AllEnums;

namespace FitOl.WebUI.Models
{
    public class MovementUpdateModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Hareket İsmi")]
        public string MovementName { get; set; }
        [Required]
        [Display(Name = "Hareket Açıklaması")]
        public string MovementDescription { get; set; }
        [Required]
        [Display(Name = "Hareket Tipi")]
        public EnumMovementType EnumMovementType { get; set; }

        public IFormFile Image { get; set; }
    }
}
