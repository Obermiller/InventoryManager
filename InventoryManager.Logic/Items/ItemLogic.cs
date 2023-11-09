using InventoryManager.Data.Repositories.Items.Contracts;
using InventoryManager.Data.Repositories.Items.Models;
using InventoryManager.Logic.Items.Contracts;

namespace InventoryManager.Logic.Items;

public class ItemLogic : IItemLogic
{
	private readonly IItemRepository _itemRepo;

	public ItemLogic(IItemRepository itemRepo)
	{
		_itemRepo = itemRepo;
	}

	public Item GetById(Guid id) => _itemRepo.GetById(id);
}