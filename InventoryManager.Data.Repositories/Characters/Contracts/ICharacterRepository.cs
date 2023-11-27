using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Data.Repositories.Characters.Contracts;

public interface ICharacterRepository
{
	void Delete(Guid id);
	Character? GetById(Guid id);
	Guid Save(Character character);
}