using BookMyShow_Models.DataModels;
using BookMyShowTask.DataModels;
using BookMyShowTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowTask.Interfaces
{
    public interface ITicketService
    {
        List<Tickets> GetAll();
        TicketDTO GetProductById(int id);
        Tickets CreateData(Tickets ticket);
        IEnumerable<int> NewTicket(int m, int t, int s);
        ActionResult BookTicket(int m, int t, int s, int ticket);
    }
}
