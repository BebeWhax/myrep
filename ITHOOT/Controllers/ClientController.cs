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
    public class ClientController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IClientService clientService)
        {
            var model = await clientService.GetAllAsync();
            return PartialView(model.ToList());
        }

        [HttpGet]
        public IActionResult Create() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Create(ClientModel model,[FromServices] IClientService clientService)
        {
            model.Id = Guid.NewGuid();
            await clientService.AddAsync(model.ToDTO());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, [FromServices] IClientService clientService)
        {
            var model = await clientService.GetAsync(id);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientModel model, [FromServices] IClientService clientService)
        {
            if (ModelState.IsValid)
            {
                await clientService.UpdateAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, [FromServices] IClientService clientService)
        {
            var model = await clientService.GetAsync(id);
            if (model == null) 
                return NotFound();

            await clientService.RemoveAsync(model.ToDTO());

            return RedirectToAction("Index");
        }
    }
}
