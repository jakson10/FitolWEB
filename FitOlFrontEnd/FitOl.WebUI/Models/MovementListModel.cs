using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class MovementListModel : IEquatable<MovementListModel>
    {
        public int FKMovementId { get; set; }
        public string MovementName { get; set; }

        public int FKAreaId { get; set; }
        //Bunu blog food ata dedıgımızda ilk gırıste aktıf kategoriler
        //checkboxta gözukmuyor ondan ekledık
        public bool Equals([AllowNull] MovementListModel other)
        {
            //bizim id miz == gelen id  ve isimleride diger gelene esit ise true döner
            return this.FKMovementId == other.FKMovementId && this.MovementName == other.MovementName;
        }
    }
}

