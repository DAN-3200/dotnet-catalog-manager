using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Entities;

namespace Persistence;

public class ProductDoc
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string? Id { get; private set; }

   public string Title { get; set; }
   public string Description { get; set; }
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
         doc.Title,
         doc.Description,
         doc.Price,
         doc.CategoryId
      );
   }
}

public class CategoryDoc
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }

   public string Title { get; set; }
   public string? Description { get; set; }

   public static CategoryDoc ToDocument(Category entity)
   {
      return new CategoryDoc
      {
         Title = entity.Title,
         Description = entity.Description
      };
   }

   public static Category ToEntity(CategoryDoc doc)
   {
      return new Category(
         doc.Title,
         doc.Description
      );
   }
}

