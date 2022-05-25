using BookMyShow_Models.DataModels;
using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using SimpleInjector;

namespace BookMyShowTask.Services
{
    public class TicketService : ITicketService
    {
        private readonly IDatabase databaseContext;
        public TicketService(Container container)
        {
            databaseContext= container.GetInstance<Database>();
        }
        public List<Tickets> GetAll()
        {
            var ticketdto = databaseContext.Query<Tickets>("SELECT * FROM Tickets").ToList();
            return ticketdto;
        }

        public TicketDTO GetProductById(int id)
        {
            var emp = databaseContext.Single<TicketDTO>("SELECT * FROM Tickets WHERE Id = @0", id);

            return emp;
        }
        public Tickets CreateData(Tickets ticket)
        {
            databaseContext.Insert(ticket);
            return ticket;
        }

        public IEnumerable<int> NewTicket(int m,int t,int s)
        {
            var a = databaseContext.Query<int>("SELECT NumberOfSeats FROM Tickets WHERE MovieId =@0 AND TheatreId=@1" +
                " AND ShowId = @2",m,t,s);
            return a;
        }

        public ActionResult BookTicket(int m,int t,int s,int ticket)
        {
            databaseContext.Update<Tickets>("SET NumberOfSeats = NumberOfSeats-@0  WHERE MovieId =@1 AND TheatreId=@2" +
                " AND ShowId = @3",ticket, m, t, s);
  
            return null;
        }

    }
}
