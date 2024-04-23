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
    }
}
