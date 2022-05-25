using BookMyShowTask.Models;

namespace BookMyShowTask.DataModels
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public DateTime ReleasedDate { get; set; }

    }
}
