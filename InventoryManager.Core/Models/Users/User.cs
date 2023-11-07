namespace InventoryManager.Core.Models.Users;

public class User
{
	public Guid Id { get; set; }
	public string Email { get; set; } = string.Empty;
}