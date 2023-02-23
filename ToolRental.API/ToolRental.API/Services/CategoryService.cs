using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ToolrentalContext _dbContext;

		public CategoryService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Models.Response.Category>> GetCategories()
		{
			var response = await _dbContext.Categories.Include(c => c.Parent).ToListAsync();
			return ToCategoryResponse(response);
		}

		private IEnumerable<Models.Response.Category> ToCategoryResponse(IEnumerable<Category> categories)
		{
			List<Models.Response.Category> response = new List<Models.Response.Category>();

			foreach (var category in categories)
			{
				if (category.Parent == null)
				{
					continue;
				}

				response.Add(new Models.Response.Category
				{
					Id = category.Id,
					Name = category.Name,
					ParentCategory = new Models.Response.Category
					{
						Id = category.Parent.Id,
						Name = category.Parent.Name,
						ParentCategory = null
					}
				});
			}

			return response;
		}
	}
}
