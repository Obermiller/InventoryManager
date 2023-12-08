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

	public async Task<bool> DeleteAsync(Guid id, Guid userId)
	{
		var dbCharacter = await ValidateCharacterAsync(id, userId);

		if (dbCharacter is null)
		{
			return false;
		}
  
		return await _characterRepo.DeleteAsync(dbCharacter);
	}

	public Task<List<Character>> GetAllAsync(Guid userId) => _characterRepo.GetAllAsync(userId);

	public async Task<Character?> GetByIdAsync(Guid id, Guid userId)
	{
		var character = await _characterRepo.GetByIdAsync(id);
		ValidateCharacter(character, userId);

		return character;
	}

	public Task<Guid> InsertAsync(Character character) => _characterRepo.InsertAsync(character);

	public Task<List<Guid>> InsertAsync(List<Character> characters) => _characterRepo.InsertAsync(characters);

	public Task<bool> UpdateAsync(Character character) => _characterRepo.UpdateAsync(character);
	
	private async Task<Character?> ValidateCharacterAsync(Guid id, Guid userId)
	{
		var dbCharacter = await GetByIdAsync(id,userId);

		ValidateCharacter(dbCharacter, userId);

		return dbCharacter;
	}

	private static void ValidateCharacter(Character? character, Guid userId)
	{
		if (character is not null && character.UserId != userId)
		{
			throw new InvalidOperationException("Character does not belong to the user.");
		}
	}
}