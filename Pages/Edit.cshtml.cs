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
        public Alumno Alumno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Alumno =  await _context.Alumno.FirstOrDefaultAsync(m => m.Id == id);
            if (Alumno == null)
            {
                return NotFound();
            }
            Alumno = Alumno;
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

            _context.Attach(Alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(Alumno.Id))
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

        private bool AlumnoExists(string id)
        {
            return _context.Alumno.Any(e => e.Id == id);
        }
    }
}
