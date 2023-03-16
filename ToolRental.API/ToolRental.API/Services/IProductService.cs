using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Models.Response.Product>> GetProducts();
		Task<IEnumerable<Models.Response.Product>> GetProductsByCategoryId(int id);
		Task<Models.Response.Product> GetProductById(int id);
	}
}
