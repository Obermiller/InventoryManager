using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Data.Repositories.Items.Contracts;

public interface IItemRepository
{
	Item GetById(Guid id);
}