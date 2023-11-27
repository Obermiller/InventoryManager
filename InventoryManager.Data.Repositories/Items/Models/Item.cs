using InventoryManager.Core.Enums.Items;

namespace InventoryManager.Data.Repositories.Items.Models;

public class Item
{
	public Guid Id { get; set; }
	public Guid? InventoryId { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int RequiredLevel { get; set; }
	public int PowerLevel { get; set; }
	public double Weight { get; set; }
	public ItemRarity Rarity { get; set; }
	public ItemSlot Slot { get; set; }
	//TODO - attributes
}