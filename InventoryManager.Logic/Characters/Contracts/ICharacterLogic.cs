using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Logic.Characters.Contracts;

public interface ICharacterLogic
{
	Character GetById(Guid id);
}