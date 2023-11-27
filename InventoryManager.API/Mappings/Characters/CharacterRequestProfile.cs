using AutoMapper;
using InventoryManager.API.Areas.Characters.Models;
using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.API.Mappings.Characters;

public class CharacterRequestProfile : Profile
{
	public CharacterRequestProfile()
	{
		CreateMap<Character, CharacterRequest>();

		CreateMap<CharacterRequest, Character>();
	}
}