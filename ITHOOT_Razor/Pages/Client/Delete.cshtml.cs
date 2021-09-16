using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using Entity;

namespace ITHOOT_Razor.Pages.Client
{
    public class DeleteModel : PageModel
    {
        private readonly DataLayer.AppContext _context;

        public DeleteModel(DataLayer.AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientEntity ClientEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientEntity = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);

            if (ClientEntity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientEntity = await _context.Clients.FindAsync(id);

            if (ClientEntity != null)
            {
                _context.Clients.Remove(ClientEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
