using ToolRental.API.Models.Response;

namespace ToolRental.API.Services;

public interface IRentalOrderService
{
	Task<IEnumerable<RentalOrder>> GetRentalOrders(int userId);
	Task<IEnumerable<Models.Response.RentalOrder>> GetAllRentalOrders();
	Task<Models.Response.RentalOrder> AcceptRentalOrder(int orderId);
	Task<Models.Response.RentalOrder> CompleteRentalOrder(int orderId);
	Task<string> AddRentalOrder(RentalOrder newOrder);
	Task DeleteRentalOrder(int id);
}