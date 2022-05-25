namespace BookMyShowTask.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } 
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
    }
}
