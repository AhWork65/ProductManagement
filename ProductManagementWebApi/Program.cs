using GlobalErrorApp.Configurations;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Service.AttributeDetail;
using ProductManagement.Services.Service.Attributes;
using ProductManagement.Services.Service.Attributes.Validation;
using ProductManagement.Services.Service.CategoryService;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.CategoryService.ValidationHanlder;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Service.Product.ValidationHanlder;
using ProductManagement.Services.Service.RelatedProductsServices;
using ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService;
using ProductManagement.Services.Services.CategoryService;
using ProductManagement.Services.Services.IServices;
using ProductManagement.Services.Services.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, Management_ProductsContext>();
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
builder.Services.AddScoped<ICategoryServiceValidation, CategoryServiceValidation>();
builder.Services.AddScoped<ICategoryValidationHanlder, CategoryValidationHanlder>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
builder.Services.AddScoped<IProductValidationHandler, ProductValidationHandler>();
builder.Services.AddScoped<IRelatedProductsService, RelatedProductService>();
builder.Services.AddScoped<IRelatedProductValidationService, RelatedProductsValidationService>();
builder.Services.AddScoped<IAttributesService, AttributesService>();
builder.Services.AddScoped<IAttributeDetailService, AttributeDetailService>();
builder.Services.AddScoped<IAttributeValidationService, AttributeValidationService>();




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

app.AddGlobalErrorHandler();

app.Run();
