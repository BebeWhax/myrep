using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer;
using Entity;

namespace ITHOOT_Razor.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly DataLayer.AppContext _context;

        public CreateModel(DataLayer.AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClientEntity ClientEntity { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(ClientEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
