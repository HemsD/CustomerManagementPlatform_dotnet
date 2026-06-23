using Lowes.CustomerManagement.Models;

namespace Lowes.CustomerManagement.Repositories;

public interface ICustomerRepository
{
    Task<Customer> CreateCustomer(Customer customer);

    Task<bool> EmailExists(string email);
}