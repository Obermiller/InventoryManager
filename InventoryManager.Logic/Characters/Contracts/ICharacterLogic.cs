using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Logic.Characters.Contracts;

public interface ICharacterLogic
{
	Task<bool> DeleteAsync(Guid id, Guid userId);
	Task<List<Character>> GetAllAsync(Guid userId);
	Task<Character?> GetByIdAsync(Guid id, Guid userId);
	Task<Guid> InsertAsync(Character character);
	Task<List<Guid>> InsertAsync(List<Character> character);
	Task<bool> UpdateAsync(Character character);
}