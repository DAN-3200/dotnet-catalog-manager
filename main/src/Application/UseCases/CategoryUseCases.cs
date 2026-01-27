using ProductCatalog.Application.Dtos;
using ProductCatalog.Application.Ports;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases;

public class CategoryUseCase(IPortsGenericRepo<Category> categoryRepo)
{
   public async Task SaveCategory(CategoryDto info)
   {
      var category = new Category(info.Title!, info.Description);
      await categoryRepo.Save(category);
   }

   public async Task<Category> GetCategory(string id)
   {
      var category = await categoryRepo.GetById(id);
      if (category is null) throw new Exception("Não há Category com tal id");

      return category;
   }

   public async Task EditCategory(string id, CategoryDto info)
   {
      var category = await categoryRepo.GetById(id);

      if (category is null) throw new Exception("Não há Category com tal id");

      if (info.Title is not null)
      {
         category.SetTitle(info.Title);
      }

      if (info.Description is not null)
      {
         category.SetDescription(info.Description);
      }

      await categoryRepo.Edit(id, category);
   }

   public async Task DeleteCategory(string id)
   {
      await categoryRepo.DeleteById(id);
   }
}



