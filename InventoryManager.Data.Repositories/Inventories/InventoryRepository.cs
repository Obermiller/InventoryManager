using InventoryManager.Core.Enums.Items;
using InventoryManager.Data.Repositories.Inventories.Contracts;
using InventoryManager.Data.Repositories.Inventories.Models;
using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Data.Repositories.Inventories;

public class InventoryRepository : IInventoryRepository
{
	public Inventory GetByCharacterId(Guid characterId)
	{
		return new Inventory
		{
			CharacterId = characterId,
			Items = new List<Item>
			{
				new()
				{
					Id = Guid.NewGuid(),
					Name = "Test Weapon",
					Description = "A unique weapon",
					PowerLevel = 823,
					RequiredLevel = 67,
					Rarity = ItemRarity.Unique,
					Slot = ItemSlot.Weapon,
					Weight = 5.12
				},
				new()
				{
					Id = Guid.NewGuid(),
					Name = "Test Helmet",
					Description = "A rare helm",
					PowerLevel = 678,
					Rarity = ItemRarity.Rare,
					Slot = ItemSlot.Helm,
					Weight = 1.45
				}
			}
		};
	}
}