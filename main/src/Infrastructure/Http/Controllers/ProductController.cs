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