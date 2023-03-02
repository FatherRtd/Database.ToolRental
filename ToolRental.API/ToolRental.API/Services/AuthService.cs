using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToolRental.API.Models;
using ToolRental.API.Models.Request;

namespace ToolRental.API.Services
{
	public class AuthService: IAuthService
	{
		private readonly ToolrentalContext _dbContext;
		private readonly IConfiguration _configuration;

		public AuthService(ToolrentalContext dbContext, IConfiguration configuration)
		{
			_dbContext = dbContext;
			_configuration = configuration;
		}

		public async Task<string> LogIn(UserRequest newUser)
		{
			var response = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			if (response == null || response.Md5password != newUser.Password)
			{
				return null;
			}

			return GenerateToken(response);
		}

		public async Task<string> CreateUser(UserRequest newUser)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			if (user != null)
			{
				return null;
			}

			var response = await _dbContext.Users.AddAsync(new Models.User()
			{
				Firstname = newUser.FirstName,
				Lastname = newUser.LastName,
				Login = newUser.Login,
				Md5password = newUser.Password,
				IsAdmin = false
			});
			_dbContext.SaveChanges();
			var newUserResponse = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == newUser.Login);
			return "Пользователь успешно зарегестрирован!";
		}

		private string GenerateToken(Models.User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var cridentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>
			{
				new Claim("id", user.Id.ToString()),
				new Claim("firstName", user.Firstname),
				new Claim("lastName", user.Lastname),
				new Claim("isAdmin", user.IsAdmin ? "1" : "0")
			};
			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], 
				claims: claims,
				expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
				notBefore: DateTime.UtcNow,
				signingCredentials: cridentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
