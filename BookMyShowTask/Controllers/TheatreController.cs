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
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService _theatreservice;
        public TheatreController(Container container)
        {
            _theatreservice = container.GetInstance<ITheatreService>();
        }
        [HttpGet]
        public Task<IEnumerable<TheatreDTO>> Get()
        {
            return _theatreservice.GetAll();
        }
        
        [HttpGet("{id}")]
        public  List<TheatreDTO> GetById(int id)
        {
            var theatre = _theatreservice.GetProductById(id);
            return theatre;
        }

    }
}
