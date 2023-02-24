using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Models.Request;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private IAuthService authService;

		public AuthController(IAuthService service)
		{
			authService = service;
		}

		[HttpPost(nameof(LogIn))]
		public async Task<ActionResult<string>> LogIn([FromBody] UserRequest user)
		{
			var response = await authService.LogIn(user);
			if (response == null)
			{
				return BadRequest("Не верное имя пользователя или пароль!");
			}
			return Ok(response);
		}

		[HttpPost(nameof(CreateUser))]
		public async Task<ActionResult<string>> CreateUser([FromBody] UserRequest user)
		{
			var response = await authService.CreateUser(user);
			if (response == null)
			{
				return BadRequest("Пользователь с таким логином уже зарегестрирован!");
			}
			return Ok(response);
		}
	}
}
