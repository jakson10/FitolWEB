using System;
using System.IO;
using System.Threading.Tasks;
using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Extensions;
using FitOl.WebUI.Filters;
using FitOl.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebUI.Controllers
{
    [Authorize(Roles = RoleConstants.AdminAndUser)]
    [JwtAuthorize]
    public class FoodController : Controller
    {
        private readonly IFoodApiService _foodApiService;

        public FoodController(IFoodApiService foodApiService)
        {
            _foodApiService = foodApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _foodApiService.GetAllAsync());
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public IActionResult Create()
        {
            return View(new FoodAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodAddModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    using (var stream = System.IO.File.Open(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        await model.Image.CopyToAsync(stream);
                    }
                    await _foodApiService.AddAsync(model, newName);
                }
                else
                {
                    await _foodApiService.AddAsync(model, null);
                }
                return RedirectToAction("Index", "Food");
            }
            return View(model);
        }


        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var foodDto = await _foodApiService.GetByIdAsync(id);
            return View(new FoodUpdateModel
            {
                Id = foodDto.Id,
                Name = foodDto.Name,
                CaloriValue = foodDto.CaloriValue,
                ProteinValue = foodDto.ProteinValue,
                CarbohydrateValue = foodDto.CarbohydrateValue,
                OilValue = foodDto.OilValue,
                FiberValue = foodDto.FiberValue,
                EnumFoodType = foodDto.EnumFoodType
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FoodUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    using (var stream = System.IO.File.Open(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    await _foodApiService.UpdateAsync(model, newName);
                }
                else
                {
                    await _foodApiService.UpdateAsync(model, null);
                }
                return RedirectToAction("Index", "Food");
            }

            return View(model);
        }


        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodApiService.DeleteAsync(id);
            return RedirectToAction("Index", "Food");
        }

        public async Task<IActionResult> Details(int id)
        {
            var foodDto = await _foodApiService.DetailsAsync(id);
            return View(foodDto);
        }


    }
}
