using ToolRental.API.Models.Request;

namespace ToolRental.API.Services
{
	public interface IAuthService
	{
		Task<Models.Response.UserResponse> LogIn(UserRequest newUser);
		Task<string> CreateUser(UserRequest newUser);
	}
}
