using Conn;
using Entities;
using Infrastructure.DependencyInjection;
using Ports;
using Repository;
using usecase;
using Infrastructure;
using Serilog;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
{
   builder.Services.AddMongo(builder.Configuration);
   builder.Services.AddControllers();
   builder.Services.AddScoped<ProductUseCase>();
   builder.Services.AddScoped<CategoryUseCase>();
   builder.Services.AddScoped<IPortsBase<Product>, ProductRepository>();
   builder.Services.AddScoped<IPortsBase<Category>, CategoryRepository>();

   builder.Host.UseSerilog((ctx, services, config) =>
   {
      config
         .ReadFrom.Configuration(ctx.Configuration)
         .ReadFrom.Services(services)
         .Enrich.FromLogContext()
         .WriteTo.Console();
   });
   builder.Services.AddSwaggerGen();
   builder.Services.AddRateLimiter(opt =>
   {
      opt.AddFixedWindowLimiter("fixed", o =>
      {
         o.Window = TimeSpan.FromSeconds(1);
         o.PermitLimit = 100;
      });
   });
}

var app = builder.Build();
{

   app.Lifetime.ApplicationStarted.Register(() =>
   {
      foreach (var url in app.Urls)
      {
         Console.WriteLine($"Listening on: {url}/swagger/index.html");
      }
   });

   if (app.Environment.IsDevelopment())
   {
      app.UseSwagger();
      app.UseSwaggerUI();
   }
   app.UseGlobalErrorHandler();
   app.UseSerilogRequestLogging();
   app.MapControllers();
}

app.Run();

