using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LAWebApplication.Data;
using LAWebApplication.Models;

namespace LAWebApplication.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly LAWebApplication.Data.LAWebApplicationContext _context;

        public DeleteModel(LAWebApplication.Data.LAWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class1 Class1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class1 = await _context.Class1.FirstOrDefaultAsync(m => m.Id == id);

            if (class1 == null)
            {
                return NotFound();
            }
            else
            {
                Class1 = class1;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class1 = await _context.Class1.FindAsync(id);
            if (class1 != null)
            {
                Class1 = class1;
                _context.Class1.Remove(Class1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
