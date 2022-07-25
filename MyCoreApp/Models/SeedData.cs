using Microsoft.EntityFrameworkCore;
using MyCoreApp.Data;

namespace MyCoreApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyCoreAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyCoreAppContext>>()))
            {
                if (context == null || context.Movie == null)
                    throw new ArgumentNullException("Null MyAppCoreContext");

                if (context.Movie.Any())
                    return;

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Утомленные солнцем",
                        ReleaseDate = DateTime.Parse("1986-07-07"),
                        Genre = "Исторический",
                        Price = 655.08M,
                        Rating = "+18"
                    },
                    new Movie
                    {
                        Title = "Охотники за привидениями",
                        ReleaseDate = DateTime.Parse("1984-03-13"),
                        Genre = "Комедия",
                        Price = 1220.99M,
                        Rating = "+16"
                    },
                    new Movie
                    {
                        Title = "Охотники за привидениями 2",
                        ReleaseDate = DateTime.Parse("1986-04-13"),
                        Genre = "Комедия",
                        Price = 1330.99M,
                        Rating = "+16"
                    }
                    ) ;
                context.SaveChanges();
            }

        }
    }
}
