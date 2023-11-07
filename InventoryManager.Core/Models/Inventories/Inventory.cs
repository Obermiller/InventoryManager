using InventoryManager.Core.Models.Items;

namespace InventoryManager.Core.Models.Inventories;

public class Inventory
{
	public Guid CharacterId { get; set; }
	public List<Item> Items { get; set; } = new();
}