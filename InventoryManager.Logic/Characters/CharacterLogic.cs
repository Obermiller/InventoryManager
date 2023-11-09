using InventoryManager.Data.Repositories.Characters.Contracts;
using InventoryManager.Data.Repositories.Characters.Models;
using InventoryManager.Logic.Characters.Contracts;

namespace InventoryManager.Logic.Characters;

public class CharacterLogic : ICharacterLogic
{
	private readonly ICharacterRepository _characterRepo;

	public CharacterLogic(ICharacterRepository characterRepo)
	{
		_characterRepo = characterRepo;
	}

	public Character GetById(Guid id) => _characterRepo.GetById(id);
}