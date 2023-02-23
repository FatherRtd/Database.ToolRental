using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : Controller
	{
		private ICategoryService categoryService;

		public CategoryController(ICategoryService service)
		{
			categoryService = service;
		}

		[HttpGet(nameof(GetCategories))]
		public async Task<ActionResult<Models.Response.Category>> GetCategories()
		{
			var result = await categoryService.GetCategories();

			return Ok(result);
		}
	}
}
