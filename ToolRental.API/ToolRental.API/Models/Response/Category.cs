namespace ToolRental.API.Models.Response
{
	public class Category
	{
		public uint Id { get; set; }
		public string? Name { get; set; }
		public Category? ParentCategory { get; set; }
	}
}
