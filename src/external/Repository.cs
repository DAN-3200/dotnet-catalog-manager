using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence;
using Ports;

namespace Repository;

public class ProductRepository : IPortsBase<Product>
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

public class CategoryRepository : IPortsBase<Category>
{
   private readonly IMongoCollection<CategoryDoc> _collection;

   public CategoryRepository(IMongoDatabase database)
   {
      _collection = database.GetCollection<CategoryDoc>("Category");
   }

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

