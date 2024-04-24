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
    public class DetailsModel : PageModel
    {
        private readonly LAWebApplication.Data.LAWebApplicationContext _context;

        public DetailsModel(LAWebApplication.Data.LAWebApplicationContext context)
        {
            _context = context;
        }

        public Alumno Alumno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Alumno = await _context.Alumno.FirstOrDefaultAsync(m => m.Id == id);
            if (Alumno == null)
            {
                return NotFound();
            }
            else
            {
                Alumno = Alumno;
            }
            return Page();
        }
    }
}
