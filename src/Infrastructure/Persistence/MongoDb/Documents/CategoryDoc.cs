using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Entities;

namespace Persistence;

public class CategoryDoc
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; } = string.Empty;
   public string Title { get; set; } = string.Empty;
   public string? Description { get; set; }

   public static CategoryDoc ToDocument(Category entity)
   {
      return new CategoryDoc
      {
         Id = entity.Id!,
         Title = entity.Title,
         Description = entity.Description
      };
   }

   public static Category ToEntity(CategoryDoc doc)
   {
      return new Category(
         doc.Id,
         doc.Title,
         doc.Description
      );
   }
}

