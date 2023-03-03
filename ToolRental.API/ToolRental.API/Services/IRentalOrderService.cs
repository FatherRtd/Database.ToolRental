using ToolRental.API.Models.Response;

namespace ToolRental.API.Services;

public interface IRentalOrderService
{
	Task<IEnumerable<RentalOrder>> GetRentalOrders(int userId);
	Task AddRentalOrder(RentalOrder newOrder);
	Task DeleteRentalOrder(int id);
}