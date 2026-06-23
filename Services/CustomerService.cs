using Lowes.CustomerManagement.Models;
using Lowes.CustomerManagement.Repositories;
using Lowes.CustomerManagement.Exceptions;

namespace Lowes.CustomerManagement.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> CreateCustomer(
        Customer customer)
    {
        if(await _repository.EmailExists(customer.Email))
        {
            throw new CustomerAlreadyExistsException(
                "Customer with email already exists");
        }

        return await _repository
            .CreateCustomer(customer);
    }
}