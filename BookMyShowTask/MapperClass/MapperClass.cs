using AutoMapper;
using BookMyShow_Models.DataModels;
using BookMyShowTask.DataModels;

namespace BookMyShowTask.Models
{
    public class MapperClass:Profile
    {
        public MapperClass()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<Theatre, TheatreDTO>();
            CreateMap<Show, ShowDTO>();
            CreateMap<Tickets, TicketDTO>();
            //CreateMap<Seat, SeatDTO>();

        }
    }
}
