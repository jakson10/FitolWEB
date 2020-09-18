using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models.Calculator
{
    public class FatRate
    {
        public double FateRate(CalculateFatRate fatRateEntities)
        {
            if (fatRateEntities.FatRateGender == FatRateGender.Male)
            {
                double BFForMen = Math.Ceiling(495 / (1.0324 - 0.19077 * Math.Log10(fatRateEntities.Waist - fatRateEntities.Neck) + 0.15456 * Math.Log10(fatRateEntities.Height)) - 450);
                return BFForMen;
            }
            else
            {
                double BFForWomen = Math.Ceiling(495 / (1.29579 - 0.35004 * Math.Log10(fatRateEntities.Waist + fatRateEntities.Hip - fatRateEntities.Neck) + 0.22100 * Math.Log10(fatRateEntities.Height)) - 450);
                return BFForWomen;
            }

        }
    }
}
