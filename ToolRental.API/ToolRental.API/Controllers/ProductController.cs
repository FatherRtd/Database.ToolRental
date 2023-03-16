using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController: Controller
	{
		private IProductService productService;

		public ProductController(IProductService service)
		{
			productService = service;
		}

		[HttpGet(nameof(GetProducts))]
		public async Task<ActionResult> GetProducts()
		{
			var result = await productService.GetProducts();

			return Ok(result);
		}

		[HttpGet(nameof(GetProductsByCategoryId))]
		public async Task<ActionResult<Models.Response.Category>> GetProductsByCategoryId(int id)
		{
			var result = await productService.GetProductsByCategoryId(id);

			return Ok(result);
		}
		[HttpGet(nameof(GetProductById))]
		public async Task<ActionResult<Models.Response.Product>> GetProductById(int id)
		{
			var result = await productService.GetProductById(id);
			if (result == null)
			{
				return BadRequest("Товар не найден!");
			}
			return Ok(result);
		}
	}
}
