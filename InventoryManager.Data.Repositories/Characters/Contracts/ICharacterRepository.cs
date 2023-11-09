using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Data.Repositories.Characters.Contracts;

public interface ICharacterRepository
{
	Character GetById(Guid id);
}