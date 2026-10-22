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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
        policy.WithOrigins("http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var server = builder.Configuration["Database:Server"];
var database = builder.Configuration["Database:DatabaseName"];
var userId = builder.Configuration["Database:UserId"];
var password = builder.Configuration["DB_PASSWORD"];

var connectionString =
    $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=True;";

builder.Services.AddDbContext<InvoicingDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        policy.WithOrigins("https://inv-angular-frontend.kindsand-e5fda325.westus2.azurecontainerapps.io")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AngularClient");
app.UseAuthorization();
app.MapControllers();

app.Run();