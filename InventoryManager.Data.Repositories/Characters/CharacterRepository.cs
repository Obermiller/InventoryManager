using DapperExtensions;
using InventoryManager.Data.Repositories.Characters.Contracts;
using InventoryManager.Data.Repositories.Characters.Models;
using Microsoft.Extensions.Configuration;

namespace InventoryManager.Data.Repositories.Characters;

public class CharacterRepository : SqlConnection, ICharacterRepository
{
	public CharacterRepository(IConfiguration config)
		: base(config) { }

	public async Task<bool> DeleteAsync(Character character)
	{
		using var conn = CreateConnection();
		var result = await conn.DeleteAsync(character);

		return result;
	}

	public async Task<List<Character>> GetAllAsync(Guid userId)
	{
		using var conn = CreateConnection();
        var characters = await conn.GetListAsync<Character>(new { UserId = userId });
        
        return characters.ToList();
	}
	
	public async Task<Character?> GetByIdAsync(Guid id)
	{
		using var conn = CreateConnection();
		var user = await conn.GetAsync<Character>(new { Id = id });
		
		return user;
	}

	public async Task<Guid> InsertAsync(Character character)
	{
		using var conn = CreateConnection();
		var id = await conn.InsertAsync(character);

		return id;
	}

	public async Task<List<Guid>> InsertAsync(List<Character> characters)
	{
		var ids = new List<Guid>();
		
		using var conn = CreateConnection();
		using var tran = conn.BeginTransaction();
		
		try
		{
			foreach (var character in characters)
			{
				var id = await conn.InsertAsync(character, tran);
				
				ids.Add(id);
			}
			
			tran.Commit();
		}
		catch (Exception)
		{
			tran.Rollback();
			throw;
		}

		return ids;
	}

	public async Task<bool> UpdateAsync(Character character)
	{
		using var conn = CreateConnection();
		var result = await conn.UpdateAsync(character);

		return result;
	}
}