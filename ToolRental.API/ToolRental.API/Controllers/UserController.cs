using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Models.Request;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class UserController: Controller
	{
		private IUserService userService;

		public UserController(IUserService service)
		{
			userService = service;
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
