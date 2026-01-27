using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Dtos;
using ProductCatalog.Application.UseCases;

namespace ProductCatalog.Infrastructure.Http.Controllers;

[ApiController]
public class ProductControllers(ProductUseCase useCase) : ControllerBase
{
   [HttpPost("product/save")]
   public async Task<IActionResult> SaveProduct([FromBody] ProductDto request)
   {
      await useCase.SaveProduct(request);
      return Created();
   }

   [HttpGet("product/get/{id}")]
   public async Task<IActionResult> GetProduct(string id)
   {
      var response = await useCase.GetProduct(id);
      return Ok(response);
   }

   [HttpPatch("product/edit/{id}")]
   public async Task<IActionResult> EditProduct(string id, ProductDto info)
   {
      await useCase.EditProduct(id, info);
      return NoContent();
   }

   [HttpDelete("product/delete/{id}")]
   public async Task<IActionResult> DeleteProduct(string id)
   {
      await useCase.DeleteProduct(id);
      return NoContent();
   }
}