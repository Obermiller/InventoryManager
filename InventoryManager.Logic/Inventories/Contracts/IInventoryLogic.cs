using InventoryManager.Data.Repositories.Inventories.Models;

namespace InventoryManager.Logic.Inventories.Contracts;

public interface IInventoryLogic
{
	Inventory GetByCharacterId(Guid characterId);
}