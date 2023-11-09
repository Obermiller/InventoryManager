using AutoMapper;
using InventoryManager.API.Areas.Characters.Models;
using InventoryManager.Data.Repositories.Characters.Models;

namespace InventoryManager.API.Mappings.Characters;

public class CharacterResponseProfile : Profile
{
	public CharacterResponseProfile()
	{
		CreateMap<Character, CharacterResponse>();

		CreateMap<CharacterResponse, Character>();
	}
}