using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public IndexModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public IList<RazorPagesMovie.Models.Movie> Movies { get; set; } = new List<RazorPagesMovie.Models.Movie>();

        public async Task OnGetAsync()
        {
            Movies = (await _repo.GetAllAsync()).ToList();
        }
    }
}