using InventoryManager.API.Areas.Items.Models;
using InventoryManager.Core.Enums.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Items.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ItemResponse>))]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[Produces("application/json")]
	public ActionResult<List<ItemResponse>> Index()
	{
		return new List<ItemResponse>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Test Weapon",
				Description = "A unique weapon",
				PowerLevel = 823,
				RequiredLevel = 67,
				Rarity = ItemRarity.Unique,
				Slot = ItemSlot.Weapon,
				Weight = 5.12
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Test Helmet",
				Description = "A rare helm",
				PowerLevel = 678,
				Rarity = ItemRarity.Rare,
				Slot = ItemSlot.Helm,
				Weight = 1.45
			}
		};
	}
}