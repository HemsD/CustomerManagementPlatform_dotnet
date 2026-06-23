using Lowes.CustomerManagement.Data;
using Lowes.CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Lowes.CustomerManagement.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _context.Customers
            .AnyAsync(c => c.Email == email);
    }

    public async Task<Customer> CreateCustomer(
        Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return customer;
    }
}