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
            // Verifica las credenciales (aqu� deber�as consultar una base de datos o alg�n otro m�todo de autenticaci�n)
            if (Id == "usuario" && Password == "contrase�a")
            {
                // Usuario autenticado correctamente
                return RedirectToAction("PaginaPrincipal");
            }
            else
            {
                // Credenciales incorrectas, muestra un mensaje de error
                string MensajeError = "Credenciales inv�lidas";
                return MensajeError;
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
