using InventoryManager.Core.Models.Inventories;

namespace InventoryManager.API.Areas.Inventories.Models;

public class InventoryResponse : Inventory
{
	public string CharacterName { get; set; } = string.Empty;
}