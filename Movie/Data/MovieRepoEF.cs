using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class MovieRepoEf : IMovieRepo
    {
        private readonly RazorPagesMovieContext _context;

        public MovieRepoEf(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IEnumerable<RazorPagesMovie.Models.Movie> GetAll()
        {
            return _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
        }

        public async Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync()
        {
            return await _context.Movie
                .OrderBy(m => m.Rank)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }

        public RazorPagesMovie.Models.Movie? GetById(int id)
        {
            return _context.Movie.FirstOrDefault(m => m.Id == id);
        }

        public async Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Add(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public async Task AddAsync(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
        }

        public void Update(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }

        public void Delete(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(RazorPagesMovie.Models.Movie movie)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Movie.Any(m => m.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Movie.AnyAsync(m => m.Id == id);
        }
    }
}