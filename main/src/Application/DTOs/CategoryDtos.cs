namespace ProductCatalog.Application.Dtos;

public record ProductDto
{
   public string? Title { get; set; }
   public string? Description { get; set; }
   public decimal? Price { get; set; }
   public CategoryDto? Category { get; set; }
}

