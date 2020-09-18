using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Calculator;

namespace FitOl.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Calculator()
        {
            var calorieCalculatorViewModel = new CaloriCalculatorViewModel
            {
                calorieCalculator = new CalorieCalculator(),
            };

            return View(calorieCalculatorViewModel);
        }

        [HttpPost]
        public IActionResult Calculator(CalorieCalculator calorieCalculator, ViewInfo viewInfo)
        {
            if (ModelState.IsValid)
            {
                CalorieCalculation hsb = new CalorieCalculation();
                ViewInfo results = hsb.Calculator(calorieCalculator, viewInfo);

                return RedirectToAction("ViewInfo", results);
            }

            return View();
        }

        public IActionResult ViewInfo(ViewInfo viewInfo)
        {
            var x = viewInfo;
            return View(x);
        }

        public IActionResult FatRate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FatRatePost(CalculateFatRate jsonData)
        {
            FatRate fatRate = new FatRate();
            double result = fatRate.FateRate(jsonData);
            return Json(result);
        }
    }
}
