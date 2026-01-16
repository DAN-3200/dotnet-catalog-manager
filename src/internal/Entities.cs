namespace Entities;

public class Product
{
   public string? Id { get; private set; }
   public string Title { get; private set; }
   public string Description { get; private set; }
   public decimal Price { get; private set; }
   public string? CategoryId { get; private set; }

   public Product(string? id, string title, string description, decimal price, string? categoryId)
   {
      Id = id;
      Title = NormalizeTitle(title);
      Description = NormalizeDescription(description);
      Price = NormalizePrice(price);
      CategoryId = NormalizeCategoryId(categoryId);
   }
   public Product(string title, string description, decimal price) : this(null, title, description, price, null)
   {
   }
   public Product(string title, string description, decimal price, string? categoryId) : this(null, title, description, price, categoryId)
   {
   }

   public void setTitle(string title)
   {
      this.Title = NormalizeTitle(title);
   }
   public void setDescription(string description)
   {
      this.Description = NormalizeDescription(description);
   }
   public void setPrice(decimal price)
   {
      this.Price = NormalizePrice(price);
   }
   public void setCategoryId(string id)
   {
      this.CategoryId = NormalizeCategoryId(id);
   }

   private string NormalizeTitle(string title)
   {
      if (string.IsNullOrWhiteSpace(title))
         throw new ArgumentException("Invalid Name");

      return title.Trim().ToUpper();
   }
   private string NormalizeDescription(string description)
   {
      if (description.Trim().Length > 50) throw new ArgumentException("The description exceeded 50 characters.");
      return description.Trim().ToLower();
   }
   private decimal NormalizePrice(decimal price)
   {
      if (decimal.IsNegative(price)) throw new ArgumentException("Invalid price - dont set negative number");
      return price;
   }
   private string? NormalizeCategoryId(string? categoryId)
   {
      if (categoryId is not null)
      {
         if (!(categoryId!.Length == 24 && categoryId.All(c => "0123456789abcdef".Contains(char.ToLower(c)))))
            throw new ArgumentException("This is inout not formated ID");
      }

      return categoryId;
   }
}

public class Category
{
   public string? Id { get; private set; }
   public string Title { get; private set; }
   public string? Description { get; private set; }

   public Category(string? id, string title, string? description)
   {
      Id = id;
      Title = NormalizeTitle(title);
      Description = NormalizeDescription(description!);
   }
   public Category(string title) : this(null, title, null)
   {
   }
   public Category(string title, string? description) : this(null, title, description)
   {
   }

   public void setTitle(string title)
   {
      this.Title = NormalizeTitle(title);
   }
   public void setDescription(string description)
   {
      this.Description = NormalizeDescription(description);
   }

   private string NormalizeTitle(string title)
   {
      if (string.IsNullOrWhiteSpace(title))
         throw new ArgumentException("Invalid Name");

      return title.Trim().ToUpper();
   }
   private string NormalizeDescription(string description)
   {
      if (description.Trim().Length > 50) throw new ArgumentException("The description exceeded 50 characters.");
      return description.Trim().ToLower();
   }
}

