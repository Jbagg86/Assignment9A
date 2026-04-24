using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rank = 4
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rank = 1

                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rank = 2
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rank = 3
                },

                new Movie
                {
                    Title = "Die Hard",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Action",
                    Price = 13.99M,
                    Rank = 10
                },

                new Movie
                {
                    Title = "Independence Day",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Science Fiction",
                    Price = 19.99M,
                    Rank = 5
                },

                new Movie
                {
                    Title = "Power Rangers",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Science Fiction",
                    Price = 20.99M,
                    Rank = 6
                },
                new Movie
                {
                    Title = "The Mask",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Comedy",
                    Price = 2.99M,
                    Rank = 7
                },
                new Movie
                {
                    Title = "The Santa Claus",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rank = 8
                }
            );
            context.SaveChanges();
        }
    }
}