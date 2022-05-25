using BookMyShowTask.DataModels;
using BookMyShowTask.Interfaces;
using BookMyShowTask.Models;
using Microsoft.Data.SqlClient;
using PetaPoco;
using PetaPoco.Providers;
using System.Data;
using AutoMapper;
using SimpleInjector;
using IMapper = AutoMapper.IMapper;

namespace BookMyShowTask.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IDatabase databaseContext;
        public CustomerService(AutoMapper.IMapper mapper,Container container)
        {
            _mapper = mapper;
            databaseContext= container.GetInstance<Database>();
        }
        public List<Customer> GetAll()
        {
            var customerdto= databaseContext.Query<Customer>("SELECT * FROM Customer").ToList();
             Task.FromResult(_mapper.Map<IEnumerable<CustomerDTO>>(customerdto));
            return customerdto;
        }

        public CustomerDTO GetProductById(int id)
        {
            var emp= databaseContext.Single<CustomerDTO>("SELECT * FROM Customer WHERE Id = @0",id);
            return emp;
        }
        public Customer CreateData(Customer customer)
        {
            var a = databaseContext.SingleOrDefault<Customer>("SELECT * FROM Customer WHERE Name = @0", customer.Name);
            if (a != null)
            {
                return null;
            }
            databaseContext.Insert(customer);
            return customer;
        }
        public CustomerDTO CheckCustomer(Login login)
        {
            var a=databaseContext.SingleOrDefault<Customer>("SELECT * FROM Customer where Email = @0", login.Email);
            if(a != null)
            {
                a= databaseContext.SingleOrDefault<Customer>("SELECT * FROM Customer where Password = @0", login.Password);
            }
            if (a != null)
            {
                return GetProductById(a.Id);
            }
            else
                return null;
            
        }

        public CustomerDTO Update(Customer customer)
        {
            databaseContext.Update(customer,customer.Id);
            return GetProductById(customer.Id);
        }

        public List<Customer> Delete(int id)
        {
            databaseContext.Delete<Customer>(id);
            return GetAll();
        }
    }
}
