using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class MovieRepoList : IMovieRepo
    {
        private readonly List<RazorPagesMovie.Models.Movie> _movies;

        public MovieRepoList()
        {
            _movies = new List<RazorPagesMovie.Models.Movie>
            {
                new RazorPagesMovie.Models.Movie { Id = 1, Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1989-2-12"), Genre = "Romantic Comedy", Price = 7.99M },
                new RazorPagesMovie.Models.Movie { Id = 2, Title = "Ghostbusters", ReleaseDate = DateTime.Parse("1984-3-13"), Genre = "Comedy", Price = 8.99M },
                new RazorPagesMovie.Models.Movie { Id = 3, Title = "Ghostbusters 2", ReleaseDate = DateTime.Parse("1986-2-23"), Genre = "Comedy", Price = 9.99M },
                new RazorPagesMovie.Models.Movie { Id = 4, Title = "Rio Bravo", ReleaseDate = DateTime.Parse("1959-4-15"), Genre = "Western", Price = 3.99M }
            };
        }

        public IEnumerable<RazorPagesMovie.Models.Movie> GetAll()
        {
            return _movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
        }

        public async Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync()
        {
            return await Task.FromResult(_movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList());
        }

        public RazorPagesMovie.Models.Movie? GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public async Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));
        }

        public void Add(RazorPagesMovie.Models.Movie movie)
        {
            _movies.Add(movie);
        }

        public async Task AddAsync(RazorPagesMovie.Models.Movie movie)
        {
            _movies.Add(movie);
            await Task.CompletedTask;
        }

        public void Update(RazorPagesMovie.Models.Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Genre = movie.Genre;
                existingMovie.Price = movie.Price;
                existingMovie.Rank = movie.Rank;
                existingMovie.ImageUri = movie.ImageUri;
            }
        }

        public async Task UpdateAsync(RazorPagesMovie.Models.Movie movie)
        {
            Update(movie);
            await Task.CompletedTask;
        }

        public void Delete(RazorPagesMovie.Models.Movie movie)
        {
            _movies.Remove(movie);
        }

        public async Task DeleteAsync(RazorPagesMovie.Models.Movie movie)
        {
            _movies.Remove(movie);
            await Task.CompletedTask;
        }

        public bool Exists(int id)
        {
            return _movies.Any(m => m.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await Task.FromResult(_movies.Any(m => m.Id == id));
        }
    }
}