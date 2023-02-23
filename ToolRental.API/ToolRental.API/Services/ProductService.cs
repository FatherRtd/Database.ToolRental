using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;
using Product = ToolRental.API.Models.Response.Product;

namespace ToolRental.API.Services
{
	public class ProductService: IProductService
	{
		private readonly ToolrentalContext _dbContext;

		public ProductService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Models.Response.Product>> GetProducts()
		{
			var response =  await _dbContext.Products.Include(pc => pc.Category.Parent).ToListAsync();
			return ToProductResponse(response);
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryId(int id)
		{
			var response = await _dbContext.Products.Where(p => p.CategoryId == id).Include(pc => pc.Category.Parent).ToListAsync();
			return ToProductResponse(response);
		}

		private IEnumerable<Models.Response.Product> ToProductResponse(IEnumerable<Models.Product> products)
		{
			List<Models.Response.Product> response = new List<Models.Response.Product>();

			foreach (var product in products)
			{
				response.Add(new Models.Response.Product
				{
					Id = product.Id,
					Name = product.Name,
					ShortDescription = product.ShortDescription,
					LongDescription = product.LongDescription,
					RentalPrice = product.RentalPrice,
					IsInStock = product.IsInStock,
					ImageSrc = product.Image,
					Category = new Models.Response.Category
					{
						Id = product.Category.Id,
						Name = product.Category.Name,
						ParentCategory = product.Category.Parent == null ? null : new Models.Response.Category
						{
							Id = product.Category.Parent.Id,
							Name = product.Category.Parent.Name,
							ParentCategory = null
						}
					}
				});
			}

			return response;
		}
	}
}
