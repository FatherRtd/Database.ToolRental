namespace ToolRental.API.Models.Response
{
	public class RentalOrder
	{
		public uint Id { get; set; }
		public User? User { get; set; }
		public Product? Product { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? OrderEndDate { get; set; }
		public uint? RentalPrice { get; set; }
		public bool IsDone { get; set; }
	}
}
