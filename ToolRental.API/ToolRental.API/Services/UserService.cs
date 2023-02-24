using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;
using ToolRental.API.Models.Request;

namespace ToolRental.API.Services
{
	public class UserService: IUserService
	{
		private readonly ToolrentalContext _dbContext;

		public UserService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Models.Response.User> LogIn(UserRequest newUser)
		{
			var response = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			if (response == null || response.Md5password != newUser.Password)
			{
				return null;
			}

			return ToUserResponse(response);
		}

		public async Task<Models.Response.User> GetUser(int id)
		{
			var response = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

			if (response == null)
			{
				return null;
			}
			return ToUserResponse(response);
		}

		public async Task<Models.Response.User> CreateUser(UserRequest newUser)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			if (user != null)
			{
				return null;
			}
			var response = await _dbContext.Users.AddAsync(new User()
			{
				Firstname = newUser.FirstName,
				Lastname = newUser.LastName,
				Login = newUser.Login,
				Md5password = newUser.Password,
				IsAdmin = false
			});
			_dbContext.SaveChanges();
			var newUserResponse = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			return ToUserResponse(newUserResponse);
		}

		private Models.Response.User ToUserResponse(User user)
		{
			var response = new Models.Response.User
			{
				Id = user.Id,
				FirstName = user.Firstname,
				LastName = user.Lastname,
				IsAdmin = user.IsAdmin,
			};
			return response;
		}
	}
}
