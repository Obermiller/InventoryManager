using InventoryManager.Data.Repositories.Inventories.Models;

namespace InventoryManager.Data.Repositories.Inventories.Contracts;

public interface IInventoryRepository
{
	Inventory GetByCharacterId(Guid characterId);
}