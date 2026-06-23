using Microsoft.EntityFrameworkCore;
using Lowes.CustomerManagement.Models;

namespace Lowes.CustomerManagement.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    } 

public DbSet<Customer> Customers { get; set; }

}