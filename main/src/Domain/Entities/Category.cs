namespace Entities;

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

