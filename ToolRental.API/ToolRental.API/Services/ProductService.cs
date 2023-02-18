using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public class ProductService: IProductService
	{
		private readonly ToolrentalContext _dbContext;

		public ProductService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _dbContext.Products.ToListAsync();

		}
	}
}
