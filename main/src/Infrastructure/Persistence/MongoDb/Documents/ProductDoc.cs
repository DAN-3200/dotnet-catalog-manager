using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Persistence.MongoDb.Documents;

public class ProductDoc
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string? Id { get; private set; }
   public string Title { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public decimal Price { get; set; }
   public string? CategoryId { get; set; }

   public static ProductDoc ToDocument(Product entity)
   {
      return new ProductDoc
      {
         Id = entity.Id,
         Title = entity.Title,
         Description = entity.Description,
         Price = entity.Price,
         CategoryId = entity.CategoryId
      };
   }

   public static Product ToEntity(ProductDoc doc)
   {
      return new Product(
         doc.Id,
         doc.Title,
         doc.Description,
         doc.Price,
         doc.CategoryId
      );
   }
}