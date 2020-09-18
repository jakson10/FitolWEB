using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class FoodListModel:IEquatable<FoodListModel>
    {
        public int FkFoodId { get; set; }
        public string Name { get; set; }

        public int FKThatDayId { get; set; }
        //Bunu blog food ata dedıgımızda ilk gırıste aktıf kategoriler
        //checkboxta gözukmuyor ondan ekledık
        public bool Equals([AllowNull] FoodListModel other)
        {
            //bizim id miz == gelen id  ve isimleride diger gelene esit ise true döner
            return this.FkFoodId == other.FkFoodId && this.Name == other.Name ;
        }
    }
}
