namespace ToolRental.API.Services
{
	public interface ICategoryService
	{
		public Task<IEnumerable<Models.Response.Category>> GetCategories();
	}
}
