using Dtos;
using Entities;
using Ports;

namespace usecase;

public class CategoryUseCase
{
   private readonly IPortsGenericRepo<Category> _categoryRepo;

   public CategoryUseCase(IPortsGenericRepo<Category> categoryRepo)
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



