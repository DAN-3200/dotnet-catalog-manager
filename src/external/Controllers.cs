using Dtos;
using Microsoft.AspNetCore.Mvc;
using usecase;

namespace Api.Controllers;

[ApiController]
public class ProductControllers(ProductUseCase _useCase) : ControllerBase
{
   [HttpPost("product/save")]
   public async Task<IActionResult> SaveProduct([FromBody] ProductDto request)
   {
      await _useCase.SaveProduct(request);
      return Created();
   }

   [HttpGet("product/get/{id}")]
   public async Task<IActionResult> GetProduct(string id)
   {
      var response = await _useCase.GetProduct(id);
      return Ok(response);
   }

   [HttpPatch("product/edit/{id}")]
   public async Task<IActionResult> EditProduct(string id, ProductDto info)
   {
      await _useCase.EditProduct(id, info);
      return NoContent();
   }

   [HttpDelete("product/delete/{id}")]
   public async Task<IActionResult> DeleteProduct(string id)
   {
      await _useCase.DeleteProduct(id);
      return NoContent();
   }
}

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