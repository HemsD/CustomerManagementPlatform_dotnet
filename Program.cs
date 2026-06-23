using Microsoft.EntityFrameworkCore;
using Lowes.CustomerManagement.Data;
using Lowes.CustomerManagement.Repositories;
using Lowes.CustomerManagement.Services;
using Lowes.CustomerManagement.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
        options.UseInMemoryDatabase("CustomerDb"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();