using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class MovementController : Controller
    {
        private readonly IMovementApiService _movementApiService;
        public MovementController(IMovementApiService movementApiService)
        {
            _movementApiService = movementApiService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _movementApiService.GetAllAsync());
        }


        [Authorize(Roles = RoleConstants.Admin)]
        public IActionResult Create()
        {
            return View(new MovementAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovementAddModel model)
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
                    await _movementApiService.AddAsync(model, newName);
                }
                else
                {
                    await _movementApiService.AddAsync(model, null);
                }
                return RedirectToAction("Index", "Movement");
            }
            return View(model);
        }


        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var movementDto = await _movementApiService.GetByIdAsync(id);
            return View(new MovementUpdateModel
            {
                Id = movementDto.Id,
                MovementName = movementDto.MovementName,
                MovementDescription = movementDto.MovementDescription,
                EnumMovementType = movementDto.EnumMovementType
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovementUpdateModel model)
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
                    await _movementApiService.UpdateAsync(model, newName);
                }
                else
                {
                    await _movementApiService.UpdateAsync(model, null);
                }
                return RedirectToAction("Index", "Movement");
            }

            return View(model);
        }


        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _movementApiService.DeleteAsync(id);
            return RedirectToAction("Index", "Movement");
        }

        public async Task<IActionResult> Details(int id)
        {
            var movementDto = await _movementApiService.DetailsAsync(id);
            return View(movementDto);
        }
    }
}
