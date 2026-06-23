using Microsoft.AspNetCore.Mvc;
using Lowes.CustomerManagement.Models;
using Lowes.CustomerManagement.Services;

namespace Lowes.CustomerManagement.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(
        ICustomerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>>
        CreateCustomer(Customer customer)
    {
        var result =
            await _service.CreateCustomer(customer);

        return CreatedAtAction(
            nameof(CreateCustomer),
            new { id = result.CustomerId },
            result);
    }
}