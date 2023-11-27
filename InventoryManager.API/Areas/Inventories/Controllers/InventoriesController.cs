using AutoMapper;
using InventoryManager.API.Areas.Inventories.Models;
using InventoryManager.Logic.Inventories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Inventories.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Produces("application/json")]
public class InventoriesController : ControllerBase
{
	private readonly IInventoryLogic _inventoryLogic;
	private readonly IMapper _mapper;

	public InventoriesController(IInventoryLogic inventoryLogic, IMapper mapper)
	{
		_inventoryLogic = inventoryLogic;
		_mapper = mapper;
	}
	
	[HttpGet, Route("[action]/{characterId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventoryResponse))]
	public ActionResult<InventoryResponse> GetForCharacter(Guid characterId)
	{
		var inventory = _inventoryLogic.GetByCharacterId(characterId);
		var response = _mapper.Map<InventoryResponse>(inventory);

		return response;
	}
}