using AutoMapper;
using InventoryManager.API.Areas.Characters.Models;
using InventoryManager.Logic.Characters.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Characters.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Produces("application/json")]
public class CharactersController : ControllerBase
{
	private readonly ICharacterLogic _characterLogic;
	private readonly IMapper _mapper;

	public CharactersController(ICharacterLogic characterLogic, IMapper mapper)
	{
		_characterLogic = characterLogic;
		_mapper = mapper;
	}
	
	[HttpGet, Route("[action]/{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
	public ActionResult<CharacterResponse> GetById(Guid id)
	{
		var character = _characterLogic.GetById(id);
		var response = _mapper.Map<CharacterResponse>(character);

		return response;
	}
}