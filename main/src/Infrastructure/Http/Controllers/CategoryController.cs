using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Dtos;
using ProductCatalog.Application.UseCases;

namespace ProductCatalog.Infrastructure.Http.Controllers;

[ApiController]
public class CategoryControllers(CategoryUseCase useCase) : ControllerBase
{
   [HttpPost("category/save")]
   public async Task<IActionResult> SaveCategory([FromBody] CategoryDto info)
   {
      await useCase.SaveCategory(info);
      return Created();
   }

   [HttpGet("category/get/{id}")]
   public async Task<IActionResult> GetCategory(string id)
   {
      var response = await useCase.GetCategory(id);
      return Ok(response);
   }

   [HttpPatch("category/edit/{id}")]
   public async Task<IActionResult> EditCategory(string id, [FromBody] CategoryDto info)
   {
      await useCase.EditCategory(id, info);
      return NoContent();
   }

   [HttpDelete("category/delete/{id}")]
   public async Task<IActionResult> DeleteCategory(string id)
   {
      await useCase.DeleteCategory(id);
      return NoContent();
   }
}