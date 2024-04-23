using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAWebApplication.Data;
using LAWebApplication.Models;

namespace LAWebApplication.Pages
{
    public class EditModel : PageModel
    {
        private readonly LAWebApplication.Data.LAWebApplicationContext _context;

        public EditModel(LAWebApplication.Data.LAWebApplicationContext context)
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

            var class1 =  await _context.Class1.FirstOrDefaultAsync(m => m.Id == id);
            if (class1 == null)
            {
                return NotFound();
            }
            Class1 = class1;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Class1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class1Exists(Class1.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Class1Exists(string id)
        {
            return _context.Class1.Any(e => e.Id == id);
        }
    }
}
