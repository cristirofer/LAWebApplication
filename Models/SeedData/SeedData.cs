using Microsoft.EntityFrameworkCore;
using LAWebApplication.Data;

namespace LAWebApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LAWebApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LAWebApplicationContext>>()))
            {
                if (context == null || context.Alumno == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Alumno.Any())
                {
                    return;   // DB has been seeded
                }

                context.Alumno.AddRange(
                    new Alumno
                    {
                        Id = "77638230M",
                        password = "Romantic Comedy",
                    },

                    new Alumno
                    {
                        Id = "77638230T",
                        password = "Romantic Comedy",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
