using BLL.Core;
using Microsoft.AspNetCore.Mvc;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;

namespace ITHOOT.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await projectService.GetAllAsync();
            return PartialView(model.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Detalis(Guid id)
        {
            var model = await projectService.GetAsync(id);
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create([FromServices] IClientService clientService)
        {
            var clients = await clientService.GetAllAsync();
            ViewData["Clients"] = new SelectList(clients,"Id","Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectModel model,[FromServices] IClientService clientService)
        {
            if (ModelState.IsValid)
            {
                await projectService.AddAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            var clients = await clientService.GetAllAsync();
            ViewData["Clients"] = new SelectList(clients, "Id", "Name",model.ClientId);
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id,[FromServices] IClientService clientService)
        {
            if (Id == Guid.Empty) 
                return BadRequest();

            var model = await projectService.GetAsync(Id);

            if (model == null) 
                return NotFound();

            var clients = await clientService.GetAllAsync();
            ViewData["Clients"] = new SelectList(clients, "Id", "Name",model.ClientId);
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectModel model, [FromServices] IClientService clientService)
        {
            if (ModelState.IsValid)
            {
                await projectService.UpdateAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            var clients = await clientService.GetAllAsync();
            ViewData["Clients"] = new SelectList(clients, "Id", "Name", model.ClientId);
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                ProjectModel model = await projectService.GetAsync(id);
                await projectService.RemoveAsync(model.ToDTO());
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
       
        
    }
}
