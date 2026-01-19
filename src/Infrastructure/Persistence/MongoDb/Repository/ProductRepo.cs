using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence;
using Ports;

namespace Repository;

public class ProductRepository : IPortsGenericRepo<Product>
{
   private readonly IMongoCollection<ProductDoc> _collection;

   public ProductRepository(IMongoDatabase database)
   {
      _collection = database.GetCollection<ProductDoc>("Product");
   }

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
