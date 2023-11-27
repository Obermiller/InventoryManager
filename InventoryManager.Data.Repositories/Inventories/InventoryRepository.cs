using InventoryManager.Core.Enums.Inventories;
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
			Id = new Guid(),
			CharacterId = characterId,
			Type = InventoryType.Items,
			Items = new List<Item>
			{
				new()
				{
					Id = Guid.NewGuid(),
					InventoryId = Guid.NewGuid(),
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
					InventoryId = null,
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