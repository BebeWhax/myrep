using BLL.Core;
using Mapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHOOT.Controllers
{
    public class PositionController : Controller
    {
        IPositionService positionService;
        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }
        public async Task<IActionResult> Index()
        {
            var model =await positionService.GetAllAsync();
            return PartialView(model.ToList());
        }
        [HttpGet]
        public IActionResult Create() => PartialView();
        [HttpPost]
        public async Task<IActionResult> Create(PositionModel model)
        {
            if (ModelState.IsValid)
            {
                await positionService.AddAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await positionService.GetAsync(id);
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PositionModel model)
        {
            if (ModelState.IsValid)
            {
                await positionService.UpdateAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }
        [HttpPost] 
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                PositionModel model = await positionService.GetAsync(id);
                await positionService.RemoveAsync(model.ToDTO());
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
