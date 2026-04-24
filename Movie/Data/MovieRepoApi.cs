using System.Net.Http.Json;

namespace RazorPagesMovie.Data
{
    public class MovieRepoApi : IMovieRepo
    {
        private readonly HttpClient _client;

        public MovieRepoApi(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<RazorPagesMovie.Models.Movie> GetAll()
        {
            return GetAllAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<RazorPagesMovie.Models.Movie>>("movies")
                   ?? new List<RazorPagesMovie.Models.Movie>();
        }

        public RazorPagesMovie.Models.Movie? GetById(int id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public async Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<RazorPagesMovie.Models.Movie>($"movies/{id}");
        }

        public void Add(RazorPagesMovie.Models.Movie movie)
        {
            AddAsync(movie).GetAwaiter().GetResult();
        }

        public async Task AddAsync(RazorPagesMovie.Models.Movie movie)
        {
            using var response = await _client.PostAsJsonAsync("movies", movie);
            response.EnsureSuccessStatusCode();
        }

        public void Update(RazorPagesMovie.Models.Movie movie)
        {
            UpdateAsync(movie).GetAwaiter().GetResult();
        }

        public async Task UpdateAsync(RazorPagesMovie.Models.Movie movie)
        {
            using var response = await _client.PutAsJsonAsync($"movies/{movie.Id}", movie);
            response.EnsureSuccessStatusCode();
        }

        public void Delete(RazorPagesMovie.Models.Movie movie)
        {
            DeleteAsync(movie).GetAwaiter().GetResult();
        }

        public async Task DeleteAsync(RazorPagesMovie.Models.Movie movie)
        {
            using var response = await _client.DeleteAsync($"movies/{movie.Id}");
            response.EnsureSuccessStatusCode();
        }

        public bool Exists(int id)
        {
            return ExistsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            return movie is not null;
        }
    }
}