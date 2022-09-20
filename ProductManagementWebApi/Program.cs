using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Service.Services;
using ProductManagement.Services.Services.Services;
using ProductManagementWebApi.Models ;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Management_ProductsContext>
    (option => 
        option.UseSqlServer("Data Source=.;Initial Catalog=Management_Products;Integrated Security=True"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
// builder.Services.AddScoped<IProductServices, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
