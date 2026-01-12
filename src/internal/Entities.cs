namespace Entities;

public class Product
{
   public string? Id { get; set; }
   public string Title { get; set; }
   public string Description { get; set; }
   public decimal Price { get; set; }
   public string? CategoryId { get; set; }

   public Product(string? id, string title, string description, decimal price, string? categoryId)
   {
      Id = id;
      Title = title;
      Description = description;
      Price = price;
      CategoryId = categoryId;
   }

   public Product(string title, string description, decimal price) : this(null, title, description, price, null)
   {
   }

   public Product(string title, string description, decimal price, string? categoryId) : this(null, title, description, price, categoryId)
   {
   }
}

public class Category
{
   public string? Id { get; set; }
   public string Title { get; set; }
   public string? Description { get; set; }

   public Category(string? id, string title, string? description)
   {
      Id = id;
      Title = title;
      Description = description;
   }

   public Category(string title) : this(null, title, null)
   {
   }

   public Category(string title, string? description) : this(null, title, description)
   {
   }
}

