using BirdSalesAPI.Data;
using BirdSalesAPI.Models;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<ApplicationDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddScoped<ISaller, SallesModel>();
builder.Services.AddScoped<ICustomer, CustomerModel>();
builder.Services.AddScoped<ICategory, CategoryModel>();
builder.Services.AddScoped<IContact, ContactModel>();
builder.Services.AddScoped<IOrder, OrderModel>();
builder.Services.AddScoped<IBird, BirdModel>();
builder.Services.AddScoped<IOrder, OrderModel>();

builder.Services.AddCors(x => x.AddPolicy(MyAllowSpecificOrigins, policy => {
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
