using BookMyShowTask.Models;

namespace BookMyShowTask.DataModels
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        
        public int NumberOfSeats { get; set; }
        public int ShowId { get; set; }

    }
}
