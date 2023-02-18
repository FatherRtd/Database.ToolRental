using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public interface IProductService
	{
		public Task<IEnumerable<Product>> GetProducts();
	}
}
