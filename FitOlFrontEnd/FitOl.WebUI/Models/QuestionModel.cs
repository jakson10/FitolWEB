using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class QuestionModel
    {
        public BesinDegeri BesinDegeri { get; set; }
        public Vejeteryan Vejeteryan { get; set; }
    }
    public enum Vejeteryan
    {
        Evet = 1,
        Hayır = 2
    }

    public enum BesinDegeri
    {
        [Display(Name = "Düşük Besin Değeri")]
        DusukBesinDegeri = 1,
        [Display(Name = "Orta Besin Değeri")]
        OrtaBesinDegeri = 2,
        [Display(Name = "Yüksek Besin Değeri")]
        YuksekBesinDegeri = 3
    }
}

