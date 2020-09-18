using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class AssignFoodModel
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public bool Exists { get; set; } //bu kategori varmı yokmu ?
    }
}
