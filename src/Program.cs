using Conn;
using Entities;
using Infrastructure.DependencyInjection;
using Ports;
using Repository;
using usecase;

var builder = WebApplication.CreateBuilder(args);
{
   builder.Services.AddSwaggerGen();
   builder.Services.AddMongo(builder.Configuration);
   builder.Services.AddControllers();
   builder.Services.AddScoped<ProductUseCase>();
   builder.Services.AddScoped<CategoryUseCase>();
   builder.Services.AddScoped<IPortsBase<Product>, ProductRepository>();
   builder.Services.AddScoped<IPortsBase<Category>, CategoryRepository>();
}


var app = builder.Build();
{
   if (app.Environment.IsDevelopment())
   {
      app.UseSwagger();
      app.UseSwaggerUI();
   }
   app.MapControllers();
}

app.Run();
