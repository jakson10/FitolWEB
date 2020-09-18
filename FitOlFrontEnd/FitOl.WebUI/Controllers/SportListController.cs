using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SportListController : Controller
    {
        private readonly ISportListApiService _sportListApiService;
        private readonly IMovementApiService _movementApiService;
        public SportListController(ISportListApiService sportListApiService, IMovementApiService movementApiService)
        {
            _sportListApiService = sportListApiService;
            _movementApiService = movementApiService;
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await _sportListApiService.GetAllAsync());
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public IActionResult Create()
        {
            return View(new SportListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SportListDto sportListDto)
        {
            if (ModelState.IsValid)
            {
                await _sportListApiService.AddAsync(sportListDto);
                return RedirectToAction("GetAll", "SportList");
            }
            return View(sportListDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _sportListApiService.DetailsAsync(id));
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _sportListApiService.DeleteAsync(id);
            return RedirectToAction("GetAll", "SportList");
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> AddMovements(int id)
        {
            return View(await _sportListApiService.DetailsAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> AddMovementForArea(int bolgeGun, int sportListId)
        {
            var response = await _sportListApiService.AddMovementForAreaAsync(bolgeGun, sportListId);

            return RedirectToAction("AssingMovement", "SportList", new { response, sportListId });

        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Movements(int id)
        {
            return View(await _sportListApiService.MovementsAsync(id));
        }


        [HttpPost]
        public async Task<JsonResult> FoodsPost(SelectMovementAndAreaModel jsonData)
        {
            await _sportListApiService.MovementsPostAsync(jsonData);
            return Json(new { status = 1, redirect = "/SportList/GetAll" });
        }


        public async Task<IActionResult> SportListView(int id)
        {
            return View(await _movementApiService.SportListDetailsAsync(id));
        }

        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> AssingMovement(int response, int sportListId)
        {

            var movements = await _movementApiService.GetAllMovementNameAsync();

            //bloguma ait kategoriler.
            //ilk anda ilgili blog için kategoriler seçili gelmicek
            //2.çözümü var 1. olarak select ile seçer tolist yaparsın bu kısımda
            //2.olarak containsi aktif olarak kullanmamız ıcın biziö bu modelin IEquatable<CategoryListModel> tagını vermen gerekiyor
            var sportListMovement = await _movementApiService.SportistAreaMovementDetailsAsync(sportListId, response);

            TempData["areaId"] = response;

            List<AssignMovementModel> list = new List<AssignMovementModel>();

            foreach (var movement in movements)
            {

                AssignMovementModel model = new AssignMovementModel();

                model.MovementId = movement.FKMovementId;
                model.MovementName = movement.MovementName;
                //categorylistmodelde yazdıgımız yapı contains dedıgımız an calısır artık
                model.Exists = sportListMovement.Contains(movement); //blogumda bu kategori var ise bu durum true olur

                list.Add(model);
            }

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> AssingMovement(List<AssignMovementModel> list)
        {
            int id = (int)TempData["areaId"];
            foreach (var item in list)
            {
                if (item.Exists)
                {
                    AreaMovementModel model = new AreaMovementModel();
                    model.FKMovementId = item.MovementId;
                    model.FKAreaId = id;
                    await _movementApiService.AddToAreaMovementAsync(model);
                }
                else
                {
                    AreaMovementModel model = new AreaMovementModel();
                    model.FKMovementId = item.MovementId;
                    model.FKAreaId = id;
                    await _movementApiService.DeleteToAreaMovementAsync(model);
                }
            }

            return RedirectToAction("GetAll", "SportList");
        }

        public IActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuestionsResult(QuestionSportModel model)
        {
            if (ModelState.IsValid)
            {
                await _sportListApiService.QuestionsResultAsync(User.Identity.Name,model);
                return RedirectToAction("SportListDetails", "User");
            }
            return RedirectToAction("Questions", "SportList");
        }

    }
}
