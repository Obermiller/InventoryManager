using InventoryManager.API.Areas.Inventories.Models;
using InventoryManager.Core.Enums.Items;
using InventoryManager.Core.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Inventories.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Produces("application/json")]
public class InventoriesController : ControllerBase
{
	[HttpGet, Route("[action]/{characterId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventoryResponse))]
	public ActionResult<InventoryResponse> GetForCharacter(Guid characterId)
	{
		return new InventoryResponse
		{
			CharacterId = characterId,
			CharacterName = "William Ramos",
			Items = new List<Item>
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
			}
		};
	}
}