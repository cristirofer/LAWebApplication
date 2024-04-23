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
    public class IndexModel : PageModel
    {
        private readonly LAWebApplication.Data.LAWebApplicationContext _context;

        public IndexModel(LAWebApplication.Data.LAWebApplicationContext context)
        {
            _context = context;
        }

        public IList<Class1> Class1 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Class1 != null)
            {
                Class1 = await _context.Class1.ToListAsync();
            }
        }
    }
}
