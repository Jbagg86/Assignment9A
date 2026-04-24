using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public interface IMovieRepo
    {
        IEnumerable<RazorPagesMovie.Models.Movie> GetAll();
        Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync();

        RazorPagesMovie.Models.Movie? GetById(int id);
        Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id);

        void Add(RazorPagesMovie.Models.Movie movie);
        Task AddAsync(RazorPagesMovie.Models.Movie movie);

        void Update(RazorPagesMovie.Models.Movie movie);
        Task UpdateAsync(RazorPagesMovie.Models.Movie movie);

        void Delete(RazorPagesMovie.Models.Movie movie);
        Task DeleteAsync(RazorPagesMovie.Models.Movie movie);

        bool Exists(int id);
        Task<bool> ExistsAsync(int id);
    }
}