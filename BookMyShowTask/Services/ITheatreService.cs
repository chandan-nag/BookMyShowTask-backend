using BookMyShowTask.DataModels;
using BookMyShowTask.Models;

namespace BookMyShowTask.Interfaces
{
    public interface ITheatreService
    {
        Task<IEnumerable<TheatreDTO>> GetAll();
       // Theatre CreateData(Theatre theatre);
        List<TheatreDTO> GetProductById(int id);
    }
}
