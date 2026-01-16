using Dtos;
using Entities;
using Ports;

namespace usecase;

public class ProductUseCase
{
   private readonly IPortsBase<Product> _productRepo;
   private readonly IPortsBase<Category> _categoryRepo;

   public ProductUseCase(IPortsBase<Product> productRepo, IPortsBase<Category> categoryRepo)
   {
      _productRepo = productRepo;
      _categoryRepo = categoryRepo;
   }

   public async Task SaveProduct(ProductDto info)
   {
      string? categoryId = null;

      if (info.Category is not null)
      {
         var category = await _categoryRepo.GetByName(info.Category.Title!);

         if (category is null)
         {
            var newCategory = new Category(info.Category.Title!, info.Category.Description);
            categoryId = await _categoryRepo.Save(newCategory);
         }
         else
         {
            categoryId = category.Id!;
         }
      }

      var product = new Product(
         info.Title!,
         info.Description!,
         (decimal)info.Price!,
         categoryId
      );

      await _productRepo.Save(product);
   }

   public async Task<Product> GetProduct(string id)
   {
      var product = await _productRepo.GetById(id);
      if (product is null) throw new Exception("Não há product com tal id");
      return product;
   }

   public async Task EditProduct(string id, ProductDto info)
   {
      var product = await _productRepo.GetById(id);
      if (product is null) throw new Exception("Não há Product com tal id");

      if (info.Title is not null)
      {
         product.setTitle(info.Title);
      }

      if (info.Description is not null)
      {
         product.setDescription(info.Description);
      }

      if (info.Price is not null)
      {
         product.setPrice((decimal)info.Price);
      }

      if (info.Category is not null)
      {
         var category = await _categoryRepo.GetByName(info.Category.Title!);
         if (category is not null)
         {
            product.setCategoryId(category.Id!);
         }
         else
         {
            var newCategoryId = await _categoryRepo.Save(
               new Category(info.Category.Title!, info.Category.Description)
            );
            product.setCategoryId(newCategoryId);
         }
      }

      await _productRepo.Edit(id, product);
   }

   public async Task DeleteProduct(string id)
   {
      await _productRepo.DeleteById(id);
   }
}

public class CategoryUseCase
{
   private readonly IPortsBase<Category> _categoryRepo;

   public CategoryUseCase(IPortsBase<Category> categoryRepo)
   {
      _categoryRepo = categoryRepo;
   }

   public async Task SaveCategory(CategoryDto info)
   {
      var category = new Category(info.Title!, info.Description);
      await _categoryRepo.Save(category);
   }

   public async Task<Category> GetCategory(string id)
   {
      var category = await _categoryRepo.GetById(id);
      if (category is null) throw new Exception("Não há Category com tal id");

      return category;
   }

   public async Task EditCategory(string id, CategoryDto info)
   {
      var category = await _categoryRepo.GetById(id);

      if (category is null) throw new Exception("Não há Category com tal id");

      if (info.Title is not null)
      {
         category.setTitle(info.Title);
      }

      if (info.Description is not null)
      {
         category.setDescription(info.Description);
      }

      await _categoryRepo.Edit(id, category);
   }

   public async Task DeleteCategory(string id)
   {
      await _categoryRepo.DeleteById(id);
   }
}




