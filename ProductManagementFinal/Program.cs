using ProductManagementDataAccess.App_Context;
using ProuctManagemetServices.Services.IServices;
using ProuctManagemetServices.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IManagementProductsContext, ManagementProductsContext>();
builder.Services.AddScoped(typeof(IActiveableEntitesDataService<>), typeof(AvtiveableEntitiesDataService<>));

    
    
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
