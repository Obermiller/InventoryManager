using DapperExtensions;
using InventoryManager.Data.Repositories.Characters.Contracts;
using InventoryManager.Data.Repositories.Characters.Models;
using Microsoft.Extensions.Configuration;

namespace InventoryManager.Data.Repositories.Characters;

public class CharacterRepository : SqlConnection, ICharacterRepository
{
	public CharacterRepository(IConfiguration config)
		: base(config) { }

	public void Delete(Guid id)
	{
		using var conn = CreateConnection();
		conn.Delete<Character>(new { Id = id });
	}
	
	public Character? GetById(Guid id)
	{
		using var conn = CreateConnection();
		
		var user = conn.Get<Character>(new { Id = id });
		
		return user;
	}

	public Guid Save(Character character)
	{
		using var conn = CreateConnection();

		if (character.Id != Guid.Empty)
		{
			conn.Update(character);
		}
		else
		{
			conn.Insert(character);
		}

		return character.Id;
	}
}