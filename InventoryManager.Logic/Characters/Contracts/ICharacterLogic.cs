using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Logic.Characters.Contracts;

public interface ICharacterLogic
{
	void Delete(Guid id);
	Character? GetById(Guid id);
	Guid Save(Character character);
}