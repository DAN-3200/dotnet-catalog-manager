using ProductCatalog.Application.Dtos;
using ProductCatalog.Application.Ports;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases;

public class ProductUseCase(
   IPortsGenericRepo<Product> productRepo,
   IPortsGenericRepo<Category> categoryRepo
)
{
   public async Task SaveProduct(ProductDto info)
   {
      string? categoryId = null;

      if (info.Category is not null)
      {
         var category = await categoryRepo.GetByName(info.Category.Title!);

         if (category is null)
         {
            var newCategory = new Category(info.Category.Title!, info.Category.Description);
            categoryId = await categoryRepo.Save(newCategory);
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

      await productRepo.Save(product);
   }

   public async Task<Product> GetProduct(string id)
   {
      var product = await productRepo.GetById(id);
      if (product is null) throw new Exception("Não há product com tal id");
      return product;
   }

   public async Task EditProduct(string id, ProductDto info)
   {
      var product = await productRepo.GetById(id);
      if (product is null) throw new Exception("Não há Product com tal id");

      if (info.Title is not null)
      {
         product.SetTitle(info.Title);
      }

      if (info.Description is not null)
      {
         product.SetDescription(info.Description);
      }

      if (info.Price is not null)
      {
         product.SetPrice((decimal)info.Price);
      }

      if (info.Category is not null)
      {
         var category = await categoryRepo.GetByName(info.Category.Title!);
         if (category is not null)
         {
            product.SetCategoryId(category.Id!);
         }
         else
         {
            var newCategoryId = await categoryRepo.Save(
               new Category(info.Category.Title!, info.Category.Description)
            );
            product.SetCategoryId(newCategoryId);
         }
      }

      await productRepo.Edit(id, product);
   }

   public async Task DeleteProduct(string id)
   {
      await productRepo.DeleteById(id);
   }
}


