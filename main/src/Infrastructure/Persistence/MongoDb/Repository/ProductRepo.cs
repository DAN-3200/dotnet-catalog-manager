using MongoDB.Driver;
using ProductCatalog.Application.Ports;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Persistence.MongoDb.Documents;

namespace ProductCatalog.Infrastructure.Persistence.MongoDb.Repository;

public class ProductRepository(IMongoDatabase database) : IPortsGenericRepo<Product>
{
   private readonly IMongoCollection<ProductDoc> _collection = database.GetCollection<ProductDoc>("Product");

   public async Task<string> Save(Product info)
   {
      var document = ProductDoc.ToDocument(info);
      await _collection.InsertOneAsync(document);
      return document.Id!;
   }

   public async Task<Product?> GetById(string id)
   {
      var res = await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();
      return res is null ? null : ProductDoc.ToEntity(res);
   }

   public async Task<Product?> GetByName(string name)
   {
      var res = await _collection.Find(i => i.Title == name).FirstOrDefaultAsync();
      return res is null ? null : ProductDoc.ToEntity(res);
   }

   public async Task Edit(string id, Product info)
   {
      await _collection.ReplaceOneAsync(i => i.Id == id, ProductDoc.ToDocument(info));
   }

   public async Task DeleteById(string id)
   {
      await _collection.DeleteOneAsync(i => i.Id == id);
   }
}
