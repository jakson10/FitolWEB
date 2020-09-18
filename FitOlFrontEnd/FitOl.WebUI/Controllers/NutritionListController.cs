using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Extensions;
using FitOl.WebUI.Filters;
using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebUI.Controllers
{
    [Authorize(Roles = RoleConstants.AdminAndUser)]
    [JwtAuthorize]
    public class NutritionListController : Controller
    {
        private readonly INutritionListApiService _nutritionListApiService;
        private readonly IFoodApiService _foodApiService;
        public NutritionListController(INutritionListApiService nutritionListApiService, IFoodApiService foodApiService)
        {
            _nutritionListApiService = nutritionListApiService;
            _foodApiService = foodApiService;
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await _nutritionListApiService.GetAllAsync());
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public IActionResult Create()
        {
            return View(new NutritionListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NutritionListDto nutritionListDto)
        {
            if (ModelState.IsValid)
            {
                await _nutritionListApiService.AddAsync(nutritionListDto);
                return RedirectToAction("GetAll", "NutritionList");
            }
            return View(nutritionListDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _nutritionListApiService.DetailsAsync(id));
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _nutritionListApiService.DetailsAsync(id);
            return RedirectToAction("GetAll", "NutritionList");
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> AddFoods(int id)
        {
            return View(await _nutritionListApiService.DetailsAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> AddFoodForThat(int ogunGun, int nutritionListId)
        {
            var response = await _nutritionListApiService.AddFoodForThatAsync(ogunGun, nutritionListId);

            return RedirectToAction("AssignFood", "NutritionList", new { response, nutritionListId });

        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Foods(int id)
        {
            return View(await _nutritionListApiService.FoodsAsync(id));
        }


        [HttpPost]
        public async Task<JsonResult> FoodsPost(SelectFoodsAndThatModel jsonData)
        {
            await _nutritionListApiService.FoodsPostAsync(jsonData);
            return Json(new { status = 1, redirect = "/NutritionList/GetAll" });
        }


        public async Task<IActionResult> NutritionListView(int id)
        {
            return View(await _foodApiService.NutritionListDetailsAsync(id));
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> AssignFood(int response, int nutritionListId)
        {

            var foods = await _foodApiService.GetAllFoodNameAsync();

            //besinime ait öğünler.
            //ilk anda ilgili besin için öğünler seçili gelmicek
            //2.çözümü var 1. olarak select ile seçer tolist yaparsın bu kısımda
            //2.olarak containsi aktif olarak kullanmamız ıcın biziö bu modelin IEquatable<AssignFoodModel> tagını vermen gerekiyor
            var nutritionListFood = await _foodApiService.NutritionListThatDayDetailsAsync(nutritionListId, response);

            TempData["thatDay"] = response;

            List<AssignFoodModel> list = new List<AssignFoodModel>();

            foreach (var food in foods)
            {
                AssignFoodModel model = new AssignFoodModel();

                model.FoodId = food.FkFoodId;
                model.FoodName = food.Name;
                //categorylistmodelde yazdıgımız yapı contains dedıgımız an calısır artık
                model.Exists = nutritionListFood.Contains(food); //besinimde bu öğün var ise bu durum true olur

                list.Add(model);
            }

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> AssignFood(List<AssignFoodModel> list)
        {
            int id = (int)TempData["thatDay"];
            foreach (var item in list)
            {
                if (item.Exists)
                {
                    MealFoodModel model = new MealFoodModel();
                    model.FKFoodId = item.FoodId;
                    model.FKThatDayId = id;
                    await _foodApiService.AddToMealFoodAsync(model);
                }
                else 
                {
                    MealFoodModel model = new MealFoodModel();
                    model.FKFoodId = item.FoodId;
                    model.FKThatDayId = id;
                    await _foodApiService.DeleteToMealFoodAsync(model);
                }
            }

            return RedirectToAction("GetAll", "NutritionList");
        }

        public IActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuestionsResult(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                await _nutritionListApiService.QuestionsResultAsync(User.Identity.Name,model);
                return RedirectToAction("NutritionListDetails", "User");
            }
            return RedirectToAction("Questions", "NutritionList");
        }

    }
}
