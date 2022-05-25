using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using PetaPoco;
using SimpleInjector;

namespace BookMyShowTask.Services
{
    public class MovieService : IMovieService
    {
        
             private readonly AutoMapper.IMapper _mapper;
        private readonly IDatabase databaseContext;
        public MovieService(AutoMapper.IMapper mapper,Container container)
        {
            _mapper = mapper;
            databaseContext = container.GetInstance<Database>();
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var moviedto = databaseContext.Query<Movie>("SELECT * FROM Movie").ToList();
            await Task.FromResult(_mapper.Map<IEnumerable<MovieDTO>>(moviedto));
            return moviedto;
        }
        public  Movie GetProductById(int id)
        {
            var emp = databaseContext.Single<Movie>("SELECT * FROM Movie WHERE Id = @0" , id);
            
            return emp;
            
        }
        
        public Movie CreateData(Movie movie)
        {
            databaseContext.Insert(movie);
            return movie;
        }
        
        public Movie Update(Movie movie)
        {
            //var databaseContext = new PetaPoco.Database("Server = BTECH1828152\\SQLEXPRESS; Database = BookMyShowDB; Trusted_Connection = True; TrustServerCertificate = True;", "System.Data.SqlClient");
            databaseContext.Update(movie);
            return GetProductById(movie.Id);
        }

        public Task<IEnumerable<Movie>> Delete(int id)
        {
            databaseContext.Delete<Movie>(id);
            return GetAll();
        }
    }
    
}
