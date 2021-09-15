using BLL.Core;
using Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHOOT.Controllers
{
    public class DeveloperController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IDeveloperService developerService)
        {
            var model = await developerService.GetAllAsync();
            return PartialView(model.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromServices] IPositionService positionService)
        {
            var positions = (await positionService.GetAllAsync());
            ViewData["Positions"] = new SelectList(positions, "Id", "Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DeveloperModel model, [FromServices] IDeveloperService developerService, [FromServices] IPositionService positionService)
        {
            if(ModelState.IsValid)
            {
                await developerService.AddAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            var positions = (await positionService.GetAllAsync());
            ViewData["Positions"] = new SelectList(positions, "Id", "Name",model.PositionId);
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id,[FromServices] IDeveloperService developerService,[FromServices] IPositionService positionService)
        {
            var model = await developerService.GetAsync(id);
            var positions = await positionService.GetAllAsync();
            ViewData["Positions"] = new SelectList(positions, "Id", "Name",model.PositionId);
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DeveloperModel model, [FromServices] IDeveloperService developerService, [FromServices] IProjectService projectService, [FromServices] IPositionService positionService)
        {
            if (ModelState.IsValid)
            {
                await developerService.UpdateAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            else
            {
                var positions = (await positionService.GetAllAsync()).Select(x => x);
                ViewData["Position"] = new SelectList(positions, "Id", "Name", model.PositionId);
                return PartialView(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id,[FromServices] IDeveloperService developerService)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                DeveloperModel model = await developerService.GetAsync(id);
                await developerService.RemoveAsync(model.ToDTO());
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

    }
}
