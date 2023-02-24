using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public class UserService: IUserService
	{
		private readonly ToolrentalContext _dbContext;

		public UserService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
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
