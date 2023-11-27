using AutoMapper;
using InventoryManager.API.Areas.Items.Models;
using InventoryManager.Logic.Items.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Items.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Produces("application/json")]
public class ItemsController : ControllerBase
{
	private readonly IItemLogic _itemLogic;
	private readonly IMapper _mapper;

	public ItemsController(IItemLogic itemLogic, IMapper mapper)
	{
		_itemLogic = itemLogic;
		_mapper = mapper;
	}
	
	[HttpGet, Route("[action]/{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemResponse))]
	public ActionResult<ItemResponse> Get(Guid id)
	{
		var item = _itemLogic.GetById(id);
		var response = _mapper.Map<ItemResponse>(item);

		return response;
	}
}