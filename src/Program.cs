using Conn;
using Entities;
using Infrastructure.DependencyInjection;
using Ports;
using Repository;
using usecase;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
{
   builder.Services.AddMongo(builder.Configuration);
   builder.Services.AddControllers();
   builder.Services.AddScoped<ProductUseCase>();
   builder.Services.AddScoped<CategoryUseCase>();
   builder.Services.AddScoped<IPortsBase<Product>, ProductRepository>();
   builder.Services.AddScoped<IPortsBase<Category>, CategoryRepository>();

   builder.Logging.ClearProviders();
   builder.Logging.AddConsole();
   builder.Logging.SetMinimumLevel(LogLevel.Information);
   builder.Services.AddHttpLogging(log =>
   {
      log.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders;
      log.RequestBodyLogLimit = 4090;
      log.ResponseBodyLogLimit = 4090;
   });
   builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
   app.UseHttpLogging();

   if (app.Environment.IsDevelopment())
   {
      app.UseSwagger();
      app.UseSwaggerUI();
   }
   app.MapControllers();
}

app.Run();
