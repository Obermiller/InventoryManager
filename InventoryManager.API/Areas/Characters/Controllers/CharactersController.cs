using AutoMapper;
using InventoryManager.API.Areas.Characters.Models;
using InventoryManager.API.Areas.Utilities;
using InventoryManager.API.Models;
using InventoryManager.Data.Repositories.Characters.Models;
using InventoryManager.Logic.Characters.Contracts;
using InventoryManager.Logic.Identity.Contracts;
using InventoryManager.Logic.Url.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Characters.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Produces("application/json")]
public class CharactersController : UtilitiesController
{
	private readonly ICharacterLogic _characterLogic;
	private readonly IMapper _mapper;

	private readonly string _baseRoute;

	public CharactersController(ICharacterLogic characterLogic, IMapper mapper, ITokenLogic tokenLogic, IUrlLogic urlLogic)
		: base(tokenLogic, urlLogic)
	{
		_characterLogic = characterLogic;
		_mapper = mapper;
		_baseRoute = GetBaseUrl() + "api/v1.0/Characters/";
	}

	[HttpPost, Route("CreateSingle")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<PostResult>> Create([FromBody] CharacterRequest request)
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}
		
		var db = _mapper.Map<Character>(request);
		db.UserId = userId;

		var id = await _characterLogic.InsertAsync(db);

		var route = _baseRoute + id;
			
		return Created(route, new PostResult { Created = id });
	}

	[HttpPost, Route("CreateMultiple")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<PostResultMultiple>> CreateMultiple([FromBody] List<CharacterRequest> requests)
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}

		var characters = MapCharacters(requests, userId);
			
		var ids = await _characterLogic.InsertAsync(characters);
			
		return Created(_baseRoute, new PostResultMultiple { Created = ids });
	}

	[HttpDelete, Route("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<string>> Delete(Guid id)
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}
		
		try
		{
			var result = await _characterLogic.DeleteAsync(id, userId);

			return result ? NoContent() : NotFound();
		}
		catch (InvalidOperationException)
		{
			return Forbid();
		}
	}

	[HttpGet, Route("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CharacterResponse>> Get(Guid id)
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}

		try
		{
			var character = await _characterLogic.GetByIdAsync(id, userId);
			if (character is null)
			{
				return NotFound();
			}

			var response = _mapper.Map<CharacterResponse>(character);
			return Ok(response);
		}
		catch (InvalidOperationException)
		{
			return Forbid();
		}
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CharacterResponse>))]
	public async Task<ActionResult<List<CharacterResponse>>> Index()
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}
		
		var characters = await _characterLogic.GetAllAsync(userId);
		var response = _mapper.Map<List<CharacterResponse>>(characters);

		return Ok(response);
	}

	[HttpPut, Route("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<ActionResult<CharacterResponse>> Update(Guid id, [FromBody] CharacterRequest request)
	{
		if (GetUserId() is not { } userId)
		{
			return Unauthorized();
		}

		Character? dbCharacter;
		try
		{
			dbCharacter = await _characterLogic.GetByIdAsync(id, userId);
		}
		catch (InvalidOperationException)
		{
			return Forbid();
		}
		
		if (dbCharacter is null)
		{
			return NoContent();
		}

		if (userId != dbCharacter.UserId)
		{
			return Conflict();
		}
		
		_mapper.Map(request, dbCharacter);

		var result = await _characterLogic.UpdateAsync(dbCharacter);

		if (result)
		{
			return Created(_baseRoute + id, new PostResult { Created = id });
		}

		return Conflict();
	}
	
	private List<Character> MapCharacters(List<CharacterRequest> requests, Guid userId)
	{
		var characters = _mapper.Map<List<Character>>(requests);
		foreach (var character in characters)
		{
			character.UserId = userId;
		}

		return characters;
	}
}