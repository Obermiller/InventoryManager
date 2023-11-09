namespace InventoryManager.Data.Repositories.Characters.Models;

public class Character
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public string Name { get; set; } = string.Empty;
}