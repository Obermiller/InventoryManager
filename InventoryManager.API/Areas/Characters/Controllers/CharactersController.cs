using AutoMapper;
using InventoryManager.API.Areas.Characters.Models;
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
public class CharactersController : ControllerBase
{
	private readonly ICharacterLogic _characterLogic;
	private readonly ITokenLogic _tokenLogic;
	private readonly IUrlLogic _urlLogic;
	private readonly IMapper _mapper;

	private string BaseRoute => _urlLogic.GetBaseUrl() + "api/v1.0/Characters/";

	public CharactersController(ICharacterLogic characterLogic, ITokenLogic tokenLogic, IUrlLogic urlLogic, IMapper mapper)
	{
		_characterLogic = characterLogic;
		_tokenLogic = tokenLogic;
		_urlLogic = urlLogic;
		_mapper = mapper;
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public ActionResult<PostResult> Create([FromBody] CharacterRequest request)
	{
		if (_tokenLogic.GetUserId(HttpContext.Request.Headers.Authorization) is { } userId)
		{
			var db = _mapper.Map<Character>(request);
			db.UserId = userId;

			var id = _characterLogic.Save(db);
			
			return Created(BaseRoute + id, new PostResult { Created = id });
		}

		return Unauthorized();
	}

	[HttpDelete, Route("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public ActionResult<string> Delete(Guid id)
	{
		if (_characterLogic.GetById(id) is not null)
		{
			_characterLogic.Delete(id);

			return NoContent();
		}

		return NotFound();
	}
	
	[HttpGet, Route("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public ActionResult<CharacterResponse> Get(Guid id)
	{
		if (_characterLogic.GetById(id) is { } character)
		{
			var response = _mapper.Map<CharacterResponse>(character);
			
			return Ok(response);
		}

		return NotFound();
	}
}