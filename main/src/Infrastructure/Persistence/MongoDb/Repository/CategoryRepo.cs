using MongoDB.Driver;
using ProductCatalog.Application.Ports;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Persistence.MongoDb.Documents;

namespace ProductCatalog.Infrastructure.Persistence.MongoDb.Repository;

public class CategoryRepository(IMongoDatabase database) : IPortsGenericRepo<Category>
{
   private readonly IMongoCollection<CategoryDoc> _collection = database.GetCollection<CategoryDoc>("Category");

   public async Task<string> Save(Category info)
   {
      var document = CategoryDoc.ToDocument(info);
      await _collection.InsertOneAsync(document);
      return document.Id;
   }

   public async Task<Category?> GetById(string id)
   {
      var res = await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();
      return res is null ? null : CategoryDoc.ToEntity(res);
   }

   public async Task<Category?> GetByName(string name)
   {
      var res = await _collection.Find(i => i.Title == name).FirstOrDefaultAsync();
      return res is null ? null : CategoryDoc.ToEntity(res);
   }

   public async Task Edit(string id, Category info)
   {
      await _collection.ReplaceOneAsync(i => i.Id == id, CategoryDoc.ToDocument(info));
   }

   public async Task DeleteById(string id)
   {
      await _collection.DeleteOneAsync(i => i.Id == id);
   }
}

