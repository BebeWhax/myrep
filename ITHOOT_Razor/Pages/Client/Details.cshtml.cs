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
    public class DetailsModel : PageModel
    {
        private readonly DataLayer.AppContext _context;

        public DetailsModel(DataLayer.AppContext context)
        {
            _context = context;
        }

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
    }
}
