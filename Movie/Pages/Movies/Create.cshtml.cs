using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using RazorPagesMovie.Utils;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieRepo _repo;
        private readonly IWebHostEnvironment _env;

        public CreateModel(IMovieRepo repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RazorPagesMovie.Models.Movie Movie { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // handle the uploaded image file if present
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                // store path in Movie.ImageUri using the injected environment instance (_env)
                Movie.ImageUri = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

            await _repo.AddAsync(Movie);

            return RedirectToPage("./Index");
        }
    }
}