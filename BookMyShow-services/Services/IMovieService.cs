using BookMyShowTask.DataModels;
using BookMyShowTask.Models;

namespace BookMyShowTask.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();
        Movie GetProductById(int id);
        Movie CreateData(Movie movie);
        Movie Update(Movie movie);

        Task<IEnumerable<Movie>> Delete(int id);
    }
}
