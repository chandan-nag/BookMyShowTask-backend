using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using BookMyShowTask.Services;
using SimpleInjector;
using System.Reflection;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using AutoMapper;
using PetaPoco;
using BookMyShowTask.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvcCore();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperClass));
builder.Services.AddCors();



var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
builder.Services.AddSimpleInjector(container, options =>
 {
     options.AddAspNetCore().AddControllerActivation();
 });
 container.Register<ICustomerService, CustomerService>();
    container.Register<IMovieService, MovieService>();
container.Register<ITheatreService, TheatreService>();
//container.Register<IShowService, ShowService>();
container.Register<ITicketService, TicketService>();
//container.Register<ISeatService, SeatService>();
container.Register<Database>(() => new PetaPoco.Database("Server = BTECH1828152\\SQLEXPRESS;" +
                " Database = BookMyShowDB; Trusted_Connection = True; " +
                "TrustServerCertificate = True;", "System.Data.SqlClient"), Lifestyle.Scoped);


/*IDatabase db= new PetaPoco.Database("Server = BTECH1828152\\SQLEXPRESS;" +
                " Database = BookMyShowDB; Trusted_Connection = True; " +
                "TrustServerCertificate = True;", "System.Data.SqlClient");
//container.Register<IDatabase, CustomerController>();*/

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.Services.UseSimpleInjector(container);
container.Verify();
// Configure the HTTP request pipeline.
app.UseCors(options =>
options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
