using ProductManagementDataAccess.App_Context;
using ProductManagementDataAccess.Repositories.Repository.Base;
using ProductManagementDomain.IRepository.Base;
using ProuctManagemetServices.Services.IServices;
using ProuctManagemetServices.Services.Service;
using ProductManagementDataAccess.Repositories.Repository;
using ProductManagementDomain.IRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IManagementProductsContext, ManagementProductsContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategorDataService , CategoryDataService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
