using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LAWebApplication.Models;

namespace LAWebApplication.Data
{
    public class LAWebApplicationContext : DbContext
    {
        public LAWebApplicationContext (DbContextOptions<LAWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<LAWebApplication.Models.Class1> Class1 { get; set; } = default!;
    }
}
