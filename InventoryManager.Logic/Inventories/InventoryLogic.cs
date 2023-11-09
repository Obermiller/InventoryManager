using InventoryManager.Data.Repositories.Inventories.Contracts;
using InventoryManager.Data.Repositories.Inventories.Models;
using InventoryManager.Logic.Inventories.Contracts;

namespace InventoryManager.Logic.Inventories;

public class InventoryLogic : IInventoryLogic
{
	private readonly IInventoryRepository _inventoryRepo;

	public InventoryLogic(IInventoryRepository inventoryRepo)
	{
		_inventoryRepo = inventoryRepo;
	}

	public Inventory GetByCharacterId(Guid characterId) => _inventoryRepo.GetByCharacterId(characterId);
}