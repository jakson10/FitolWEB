using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class ProfileEditing
    {
        [Required()]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Kalori kısmı boş geçilemez")]
        [Display(Name = "Almanız Gereken Kalori Miktarınızı Giriniz ")]
        public int Calorie { get; set; }
        [Required(ErrorMessage = "Kilo boş geçilemez")]
        [Display(Name = "Kilonuzu Giriniz")] 
        public int Weight { get; set; }
        [Required(ErrorMessage = "Boy boş geçilemez")]
        [Display(Name = "Boyunuzu Giriniz")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Yağ oranı boş geçilemez")]
        [Display(Name = "Yağ Oranınızı Giriniz ")]
        public double FatRate { get; set; }

        [Required(ErrorMessage = "Yaş  boş geçilemez")]
        [Display(Name = "Yaşınızı Giriniz ")]
        public int Age { get; set; }
    }
}
