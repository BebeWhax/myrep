using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using Entity;
using BLL.Core;
using Model;
using Mapper;

namespace ITHOOT_Razor.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.AppContext _context;

        public IndexModel(DataLayer.AppContext context)
        {
            _context = context;
        }
        public IList<ClientEntity> ClientsEntity { get;set; }

        
        [BindProperty]
        public ClientEntity ClientEntity { get; set; }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(ClientEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id, [FromServices] IClientService clientService)
        {
            var model = await clientService.GetAsync(id);
            if (model == null)
                return NotFound();

            await clientService.RemoveAsync(model.ToDTO());

            return RedirectToPage("./Index");
        }
        public async Task OnGetAsync()
        {
            ClientsEntity = await _context.Clients.ToListAsync();
        }
        public async Task<IActionResult> OnGetEditAsync(Guid id, [FromServices] IClientService clientService)
        {
            var model = await clientService.GetAsync(id);
            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostEditAsync(ClientModel model, [FromServices] IClientService clientService)
        {
            if (ModelState.IsValid)
            {
                await clientService.UpdateAsync(model.ToDTO());
                return RedirectToAction("Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
