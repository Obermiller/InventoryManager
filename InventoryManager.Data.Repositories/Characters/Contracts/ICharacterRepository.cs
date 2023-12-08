using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Data.Repositories.Characters.Contracts;

public interface ICharacterRepository
{
	Task<bool> DeleteAsync(Character character);
	Task<List<Character>> GetAllAsync(Guid userId);
	Task<Character?> GetByIdAsync(Guid id);
	Task<Guid> InsertAsync(Character character);
	Task<List<Guid>> InsertAsync(List<Character> characters);
	Task<bool> UpdateAsync(Character character);
}