using Dtos;
using Microsoft.AspNetCore.Mvc;
using usecase;

namespace Api.Controllers;

[ApiController]
public class CategoryControllers(CategoryUseCase _useCase) : ControllerBase
{
   [HttpPost("category/save")]
   public async Task<IActionResult> SaveCategory([FromBody] CategoryDto info)
   {
      await _useCase.SaveCategory(info);
      return Created();
   }

   [HttpGet("category/get/{id}")]
   public async Task<IActionResult> GetCategory(string id)
   {
      var response = await _useCase.GetCategory(id);
      return Ok(response);
   }

   [HttpPatch("category/edit/{id}")]
   public async Task<IActionResult> EditCategory(string id, [FromBody] CategoryDto info)
   {
      await _useCase.EditCategory(id, info);
      return NoContent();
   }

   [HttpDelete("category/delete/{id}")]
   public async Task<IActionResult> DeleteCategory(string id)
   {
      await _useCase.DeleteCategory(id);
      return NoContent();
   }
}