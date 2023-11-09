using InventoryManager.Data.Repositories.Characters.Contracts;
using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Data.Repositories.Characters;

public class CharacterRepository : ICharacterRepository
{
	public Character GetById(Guid id)
	{
		return new Character
		{
			Id = id,
			UserId = Guid.NewGuid(),
			Name = "William Ramos"
		};
	}
}