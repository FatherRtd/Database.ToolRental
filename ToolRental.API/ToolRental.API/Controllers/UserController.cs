using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Models.Request;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController: Controller
	{
		private IUserService userService;

		public UserController(IUserService service)
		{
			userService = service;
		}

		[HttpPost(nameof(LogIn))]
		public async Task<ActionResult<UserRequest>> LogIn([FromBody] UserRequest user)
		{
			var response = await userService.LogIn(user);
			if (response == null)
			{
				return BadRequest("Не верное имя пользователя или пароль!");
			}
			return Ok(response);
		}

		[HttpPost(nameof(CreateUser))]
		public async Task<ActionResult<UserRequest>> CreateUser([FromBody] UserRequest user)
		{
			var response = await userService.CreateUser(user);
			if (response == null)
			{
				return BadRequest("Пользователь с таким логином уже зарегестрирован!");
			}
			return Ok(response);
		}

		[HttpGet(nameof(GetUser))]
		public async Task<ActionResult<UserRequest>> GetUser(int id)
		{
			var response = await userService.GetUser(id);
			if (response == null)
			{
				return BadRequest("Пользователь не найден!");
			}
			return Ok(response);
		}
	}
}
