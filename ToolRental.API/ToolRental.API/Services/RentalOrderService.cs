using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
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

		public async Task<IEnumerable<Models.Response.RentalOrder>> GetAllRentalOrders()
		{
			var response = await _dbContext.RentalOrders
				.Include(x => x.User)
				.Include(x => x.Product)
				.Include(x => x.Product.Category)
				.ToListAsync();
			return ToRentalOrderResponse(response);
		}

		public async Task<Models.Response.RentalOrder> AcceptRentalOrder(int orderId)
		{
			var query = await _dbContext.RentalOrders.Where(x => x.Id == orderId)
				.Include(x => x.User)
				.Include(x => x.Product)
				.Include(x => x.Product.Category).FirstOrDefaultAsync();
			query.OrderDate = DateTime.Now;

			_dbContext.RentalOrders.Update(query);
			_dbContext.SaveChanges();

			var result = new List<RentalOrder>();
			result.Add(query);

			return ToRentalOrderResponse(result).First();
		}

		public async Task<Models.Response.RentalOrder> CompleteRentalOrder(int orderId)
		{
			var query = await _dbContext.RentalOrders.Where(x => x.Id == orderId)
				.Include(x => x.User)
				.Include(x => x.Product)
				.Include(x => x.Product.Category).FirstOrDefaultAsync();
			query.OrderEndDate = DateTime.Now;
			query.RentalPrice = (uint?)(((TimeSpan)(query.OrderEndDate - query.OrderDate)).Days * query.Product.RentalPrice);

			_dbContext.RentalOrders.Update(query);
			_dbContext.SaveChanges();

			var result = new List<RentalOrder>();
			result.Add(query);

			return ToRentalOrderResponse(result).First();
		}

		public async Task<string> AddRentalOrder(Models.Response.RentalOrder newOrder)
		{
			var query = await _dbContext.RentalOrders.AddAsync(new Models.RentalOrder()
			{
				UserId = newOrder.User.Id,
				ProductId = newOrder.Product.Id,
				OrderDate = null,
				OrderEndDate = null,
				RentalPrice = null,
				IsDone = false,
			});

			_dbContext.SaveChanges();

			return "Заказ добавлен";
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
