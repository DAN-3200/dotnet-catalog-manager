namespace Entities;

public class Product
{
   public string? Id { get; private set; }
   public string Title { get; set; }
   public string Description { get; set; }
   public decimal Price { get; set; }
   public string? CategoryId { get; set; }

   public Product(string title, string description, decimal price) : this(title, description, price, null)
   {
   }

   public Product(string title, string description, decimal price, string? categoryId)
   {
      Title = title;
      Description = description;
      Price = price;
      CategoryId = categoryId;
   }
}

public class Category
{
   public string? Id { get; set; }
   public string Title { get; set; }
   public string? Description { get; set; }

   public Category(string title) : this(title, null)
   {
   }

   public Category(string title, string? description)
   {
      Title = title;
      Description = description;
   }
}

