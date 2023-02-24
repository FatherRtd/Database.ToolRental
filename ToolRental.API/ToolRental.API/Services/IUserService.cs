using ToolRental.API.Models;
using ToolRental.API.Models.Request;

namespace ToolRental.API.Services
{
	public interface IUserService
	{
		Task<Models.Response.User> GetUser(int id);
	}
}
