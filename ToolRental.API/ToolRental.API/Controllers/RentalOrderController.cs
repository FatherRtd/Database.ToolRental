using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet(nameof(GetAllRentalOrders))]
		public async Task<ActionResult<IEnumerable<Models.Response.RentalOrder>>> GetAllRentalOrders()
		{
			var result = await rentalOrderService.GetAllRentalOrders();
			return Ok(result);
		}

		[HttpGet(nameof(CompleteRentalOrder))]
		public async Task<ActionResult<Models.Response.RentalOrder>> CompleteRentalOrder(int orderId)
		{
			var result = await rentalOrderService.CompleteRentalOrder(orderId);
			return Ok(result);
		}

		[HttpGet(nameof(AcceptRentalOrder))]
		public async Task<ActionResult<Models.Response.RentalOrder>> AcceptRentalOrder(int orderId)
		{
			var result = await rentalOrderService.AcceptRentalOrder(orderId);
			return Ok(result);
		}

		[HttpPost(nameof(CreateRentalOrder))]
		public async Task<ActionResult> CreateRentalOrder([FromBody] Models.Response.RentalOrder newOrder)
		{
			var result = await rentalOrderService.AddRentalOrder(newOrder);
			return Ok("Заказ создан");
		}
	}
}
