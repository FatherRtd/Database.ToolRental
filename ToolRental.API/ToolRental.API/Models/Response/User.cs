namespace ToolRental.API.Models.Response
{
	public class User
	{
		public uint Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public bool IsAdmin { get; set; }
	}
}
