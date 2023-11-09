using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.Logic.Items.Contracts;

public interface IItemLogic
{
	Item GetById(Guid id);
}