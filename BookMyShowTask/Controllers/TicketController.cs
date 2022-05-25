using BookMyShow_Models.DataModels;
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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketservice;
        public TicketController(Container container)
        {
            _ticketservice = container.GetInstance<ITicketService>();
        }
        [HttpGet]
        public List<Tickets> Get()
        {
            return _ticketservice.GetAll();
        }
        [HttpGet("id")]
        public TicketDTO GetById(int id)
        {
            return _ticketservice.GetProductById(id);
        }
        [HttpPost]
        public Tickets Create(Tickets ticket)
        {
            return _ticketservice.CreateData(ticket);
        }
        [HttpGet("{MovieId}/{TheatreId}/{ShowId}")]
        public IEnumerable<int> CreateTicket(int MovieId, int TheatreId, int ShowId)
        {
            return _ticketservice.NewTicket(MovieId, TheatreId, ShowId);
        }
        [HttpGet("{MovieId}/{TheatreId}/{ShowId}/{tickets}")]
        public ActionResult Update(int MovieId, int TheatreId, int ShowId, int tickets)
        {
            return Ok( _ticketservice.BookTicket(MovieId, TheatreId, ShowId, tickets));
        }
    }
}
