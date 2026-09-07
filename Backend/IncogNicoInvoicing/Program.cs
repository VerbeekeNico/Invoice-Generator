using Invoicing.Business;
using Invoicing.Business.Interfaces;
using Invoicing.Contract;
using Invoicing.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDemoDataProvider, DemoDataProvider>();
builder.Services.AddScoped<DemoDataDtoMapper>();
builder.Services.AddScoped<IDemoRepository, DemoRepository>();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();
builder.Services.AddScoped<IWorkItemRepository, DemoRepository>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<InvoicingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Invoicing")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();