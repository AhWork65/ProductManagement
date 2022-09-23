using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Service.Attributes;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Service.Services;
using ProductManagement.Services.Services.IServices;
using ProductManagement.Services.Services.Services;
using ProductManagementWebApi.Models ;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, Management_ProductsContext>();
// builder.Services.AddDbContext<Management_ProductsContext>
//     (option => 
//         option.UseSqlServer("Data Source=.;Initial Catalog=Management_Products;Integrated Security=True"));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRelatedProductRepository, RelatedProductsRepository>();
builder.Services.AddScoped<IAttributesRepository, AttributeRepository>();
builder.Services.AddScoped<IAttributeDetailRepository, AttributeDetailsRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
builder.Services.AddScoped<IAttributesService, AttributesService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
