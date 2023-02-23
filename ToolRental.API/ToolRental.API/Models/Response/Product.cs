namespace ToolRental.API.Models.Response
{
	public class Product
	{
		public uint Id { get; set; }
		public string? Name { get; set; }
		public string? ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public uint RentalPrice { get; set; }
		public bool IsInStock { get; set; }
		public string? ImageSrc { get; set; }
		public Category? Category { get; set; }
	}
}
