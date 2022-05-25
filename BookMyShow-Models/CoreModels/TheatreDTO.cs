using BookMyShowTask.Models;

namespace BookMyShowTask.DataModels
{
    public class TheatreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MovieId { get; set; }
    }
}
