namespace ToolRental.API.Models.Request
{
	public class ProductRequest
	{
		public string? Name { get; set; }
		public string? ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public uint RentalPrice { get; set; }
		public IFormFile Image { get; set; }
		public uint CategoryId { get; set; }
	}
}
