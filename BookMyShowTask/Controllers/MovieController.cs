using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;

namespace BookMyShowTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieservice;
        public MovieController(Container container)
        {
            _movieservice= container.GetInstance<IMovieService>();
        }
        [HttpGet]
        public  Task<IEnumerable<Movie>> Get()
        {
            return _movieservice.GetAll();
        }
        [HttpGet("{id}")]
        public  Movie GetById(int id)
        {
            var movie= _movieservice.GetProductById(id);
            return movie;
        }
        
        [HttpPost]
        public Movie Create(Movie movie)
        {
            return _movieservice.CreateData(movie);
        }
        
        [HttpPut]
        public Movie UpdateData(Movie movie)
        {
            return _movieservice.Update(movie);
        }
        [HttpDelete("id")]
        public  Task<IEnumerable<Movie>> DeleteData(int id)
        {
            return  _movieservice.Delete(id);
        }
    }
}
