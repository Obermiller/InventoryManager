using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Data.Repositories.Inventories.Models;

public class Inventory
{
	public Guid CharacterId { get; set; }
	public List<Item> Items { get; set; } = new();
}