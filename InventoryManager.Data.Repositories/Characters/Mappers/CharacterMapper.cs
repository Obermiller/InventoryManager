using DapperExtensions.Mapper;
using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.Data.Repositories.Characters.Mappers;

public class CharacterMapper : ClassMapper<Character>
{
	public CharacterMapper()
	{
		Table(nameof(Character));

		Map(x => x.Id).Key(KeyType.Guid);

		AutoMap();
	}
}