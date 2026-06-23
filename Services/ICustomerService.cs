using Lowes.CustomerManagement.Models;

namespace Lowes.CustomerManagement.Services;

public interface ICustomerService
{
    Task<Customer> CreateCustomer(Customer customer);
}