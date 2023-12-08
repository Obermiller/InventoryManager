namespace InventoryManager.Core.Models.Characters;

public class Character
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int Level { get; set; }
}