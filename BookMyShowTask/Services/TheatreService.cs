using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using PetaPoco;
using SimpleInjector;

namespace BookMyShowTask.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IDatabase databaseContext;
        public TheatreService(AutoMapper.IMapper mapper,Container container)
        {
            _mapper = mapper;
            databaseContext=  container.GetInstance<Database>();
        }
        public Task<IEnumerable<TheatreDTO>> GetAll()
        {
            var customerdto = databaseContext.Query<Theatre>("SELECT * FROM Theatre").ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<TheatreDTO>>(customerdto));
        }
        public List<TheatreDTO> GetProductById(int id)
        {
            var emp = databaseContext.Query<TheatreDTO>("SELECT * FROM Theatre WHERE MovieId = @0", id).ToList();
            //emp.shows = databaseContext.Query<Show>("SELECT * FROM Show WHERE TheatreId = @0",id).ToList();
            return emp;
        }
        
    }
}
