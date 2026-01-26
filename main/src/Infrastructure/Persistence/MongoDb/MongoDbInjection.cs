using ConnDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.DependencyInjection;

public static class MongoExtension
{
   public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
   {
      services.Configure<MongoDbSettings>(
         configuration.GetSection("MongoDbSettings")
      );
      services.AddSingleton<IMongoClient>(sp =>
      {
         var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
         return new MongoClient(settings.ConnectionString);
      });
      services.AddSingleton(sp =>
      {
         var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
         var client = sp.GetRequiredService<IMongoClient>();
         return client.GetDatabase(settings.DatabaseName);
      });

      return services;
   }
}