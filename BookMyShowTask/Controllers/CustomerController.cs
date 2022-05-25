using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using SimpleInjector;

namespace BookMyShowTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerservice;
        public CustomerController(Container container)
        {
            _customerservice = container.GetInstance<ICustomerService>();
            //db = container.GetInstance<Database>();
        }
        [HttpGet]
        public  List<Customer> Get()
        {
            return  _customerservice.GetAll();
        }
        [HttpGet("id")]
        public CustomerDTO GetById(int id)
        {
            return _customerservice.GetProductById(id);
        }
        [HttpPost("register")]
        public Customer RegisterNewCustomer(Customer customer)
        {
            return _customerservice.CreateData(customer);
        }
        [HttpPost("login")]
        public CustomerDTO LoginCustomer(Login login)
        {
            return _customerservice.CheckCustomer(login);
        }

        [HttpPut]
        public CustomerDTO UpdateData(Customer customer)
        {
            return _customerservice.Update(customer);
        }
        [HttpDelete("id")]
        public List<Customer> DeleteData(int id)
        {
            return _customerservice.Delete(id);
        }
    }
}
