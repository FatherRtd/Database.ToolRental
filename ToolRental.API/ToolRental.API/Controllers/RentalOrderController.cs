using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolRental.API.Models;
using ToolRental.API.Services;

namespace ToolRental.API.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class RentalOrderController : Controller
	{
		private IRentalOrderService rentalOrderService;

		public RentalOrderController(IRentalOrderService service)
		{
			rentalOrderService = service;
		}

		[HttpGet(nameof(GetRentalOrders))]
		public async Task<ActionResult<IEnumerable<Models.Response.RentalOrder>>> GetRentalOrders(int userId)
		{
			var result = await rentalOrderService.GetRentalOrders(userId);
			return Ok(result);
		}
	}
}
