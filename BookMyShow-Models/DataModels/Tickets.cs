using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_Models.DataModels
{
    public class Tickets
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheatreId { get; set; }

        public int NumberOfSeats { get; set; }
        public int ShowId { get; set; }
    }
}
