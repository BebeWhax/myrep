using BLL.Core;
using Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITHOOT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHOOT.Controllers
{
    public class DeveloperOnProjectController : Controller
    {
        IProjectService projectService;

        public DeveloperOnProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> AddDeveloperOnProject(Guid projectId,[FromServices] IDeveloperService developerService)
        {
            if (projectId == Guid.Empty) 
                return BadRequest();
            var entry = await projectService.GetAsync(projectId);
            if (entry == null)
                return NotFound();
            DeveloperOnProjectViewModel model = new DeveloperOnProjectViewModel { ProjectId = entry.Id };
            var projects = await projectService.GetAllAsync();

            ViewData["Projects"] = new SelectList(projects, "Id", "Name", entry.Id);
            var developers = await developerService.GetAllAsync();
            ViewData["Developers"] = new SelectList(developers, "Id", "Name");
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddDeveloperOnProject(DeveloperOnProjectViewModel model, [FromServices] IDeveloperService developerService)
        {
            if (model.DeveloperId == Guid.Empty)
            { 
                ModelState.AddModelError("DeveloperId", "Не обраний розробник");
            }
            if (ModelState.IsValid)
            {
                var entryProject = await projectService.GetAsync(model.ProjectId);
                var entryDeveloper = await developerService.GetAsync(model.DeveloperId);
                if (entryDeveloper == null || entryProject==null)
                    return NotFound();

                entryProject.Developers.Add(entryDeveloper);

                await projectService.UpdateAsync(entryProject.ToDTO());

                return RedirectToAction("Detalis", "Project", new { id = model.ProjectId });
            }
            var projects = await projectService.GetAllAsync();
            ViewData["Projects"] = new SelectList(projects, "Id", "Name", model.ProjectId);
            var developers = await developerService.GetAllAsync();
            ViewData["Developers"] = new SelectList(developers, "Id", "Name",model.DeveloperId);
            return PartialView(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> RemoveDeveloperOnProject(Guid projectId, Guid developerId)
        {
            var entryProject = await projectService.GetAsync(projectId);
            var entryDeveloper = entryProject.Developers.First(p => p.Id == developerId);
            if (entryDeveloper == null || entryProject == null)
                return NotFound();
            entryProject.Developers.Remove(entryDeveloper);
            await projectService.UpdateAsync(entryProject.ToDTO());
            return RedirectToAction("Detalis", "Project", new { id = projectId });
        }
    }
}
