using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public DetailsModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public RazorPagesMovie.Models.Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repo.GetByIdAsync(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            Movie = movie;
            return Page();
        }
    }
}