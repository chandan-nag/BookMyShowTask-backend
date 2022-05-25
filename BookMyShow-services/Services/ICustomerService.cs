using BookMyShowTask.DataModels;
using BookMyShowTask.Models;

namespace BookMyShowTask.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        CustomerDTO GetProductById(int id);
        Customer CreateData(Customer customer);
        CustomerDTO CheckCustomer(Login login);
        CustomerDTO Update(Customer customer);
        List<Customer> Delete(int id);
    }
}
