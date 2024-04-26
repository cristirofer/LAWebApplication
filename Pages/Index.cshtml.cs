using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LAWebApplication.Data;
using LAWebApplication.Models;
using System.Drawing.Printing;

namespace LAWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LAWebApplication.Data.LAWebApplicationContext _context;

        public IndexModel(LAWebApplication.Data.LAWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult IniciarSesion(string Id, string Password)
        {
            string script = "<script>document.getElementById('incorrectLabel').style.visibility = 'hidden';</script>";
            // Verifica las credenciales (aquí deberías consultar una base de datos o algún otro método de autenticación)
            if (Id == "usuario" && Password == "contraseña")
            {
                // Usuario autenticado correctamente
                return RedirectToAction("PaginaPrincipal");
            }
            else
            {
                script = "<script>document.getElementById('incorrectLabel').style.visibility = 'visible';</script>";
                return RedirectToAction("PaginaPrincipal");
            }
        }

        

        public IList<Alumno> Alumno { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Alumno != null)
            {
                Alumno = await _context.Alumno.ToListAsync();
            }
        }

    }
}
