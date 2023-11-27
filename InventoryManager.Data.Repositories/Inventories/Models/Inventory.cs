using InventoryManager.Core.Enums.Inventories;
using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Data.Repositories.Inventories.Models;

public class Inventory
{
	public Guid Id { get; set; }
	public Guid CharacterId { get; set; }
	public InventoryType Type { get; set; }
	public List<Item> Items { get; set; } = new();
}