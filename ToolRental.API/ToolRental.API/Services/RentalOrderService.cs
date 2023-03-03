using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;

namespace ToolRental.API.Services
{
	public class RentalOrderService : IRentalOrderService
	{
		private readonly ToolrentalContext _dbContext;

		public RentalOrderService(ToolrentalContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Models.Response.RentalOrder>> GetRentalOrders(int userId)
		{
			var response = await _dbContext.RentalOrders.Where(x => x.UserId == userId)
				.Include(x => x.User)
				.Include(x => x.Product)
				.Include(x => x.Product.Category)
				.ToListAsync();
			return ToRentalOrderResponse(response);
		}

		public Task AddRentalOrder(Models.Response.RentalOrder newOrder)
		{
			throw new NotImplementedException();
		}

		public Task DeleteRentalOrder(int id)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<Models.Response.RentalOrder> ToRentalOrderResponse(IEnumerable<RentalOrder> orders)
		{
			var response = new List<Models.Response.RentalOrder>();
			foreach (var order in orders)
			{
				response.Add(new Models.Response.RentalOrder
				{
					Id = order.Id,
					User = new Models.Response.User
					{
						Id = order.User.Id,
						FirstName = order.User.Firstname,
						LastName = order.User.Lastname,
						IsAdmin = order.User.IsAdmin,
					},
					Product = new Models.Response.Product
					{
						Id = order.Product.Id,
						Name = order.Product.Name,
						ShortDescription = order.Product.ShortDescription,
						LongDescription = order.Product.LongDescription,
						RentalPrice = order.Product.RentalPrice,
						IsInStock = order.Product.IsInStock,
						ImageSrc = order.Product.Image,
						Category = new Models.Response.Category
						{
							Id = order.Product.Category.Id,
							Name = order.Product.Category.Name,
							ParentCategory = order.Product.Category.Parent == null ? null : new Models.Response.Category
							{
								Id = order.Product.Category.Parent.Id,
								Name = order.Product.Category.Parent.Name,
								ParentCategory = null
							}
						}
					},
					OrderDate = order.OrderDate,
					OrderEndDate = order.OrderEndDate,
					RentalPrice = order.RentalPrice,
					IsDone = order.IsDone,
				});
			}
			return response;
		}
	}
}
