using InventoryManager.Core.Enums.Items;
using InventoryManager.Data.Repositories.Items.Contracts;
using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Data.Repositories.Items;

public class ItemRepository : IItemRepository
{
	public Item GetById(Guid id)
	{
		return new Item
		{
			Id = Guid.NewGuid(),
			Name = "Test Weapon",
			Description = "A unique weapon",
			PowerLevel = 823,
			RequiredLevel = 67,
			Rarity = ItemRarity.Unique,
			Slot = ItemSlot.Weapon,
			Weight = 5.12
		};
	}
}