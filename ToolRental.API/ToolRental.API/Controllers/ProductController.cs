using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
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
	}
}
