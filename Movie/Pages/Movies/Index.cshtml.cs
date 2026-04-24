using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public IndexModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public IList<RazorPagesMovie.Models.Movie> Movie { get; set; } = new List<RazorPagesMovie.Models.Movie>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = (await _repo.GetAllAsync()).ToList();

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title != null && s.Title.Contains(SearchString)).ToList();
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre).ToList();
            }

            Genres = new SelectList(movies
                .Select(m => m.Genre)
                .Where(g => !string.IsNullOrEmpty(g))
                .Distinct()
                .OrderBy(g => g)
                .ToList());

            Movie = movies
                .OrderBy(m => m.Rank)
                .ThenBy(m => m.Title)
                .ToList();
        }
    }
}