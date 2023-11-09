using AutoMapper;
using InventoryManager.API.Areas.Inventories.Models;
using InventoryManager.Data.Repositories.Inventories.Models;

namespace InventoryManager.API.Mappings.Inventories;

public class InventoryResponseProfile : Profile
{
	public InventoryResponseProfile()
	{
		CreateMap<Inventory, InventoryResponse>();

		CreateMap<InventoryResponse, Inventory>();
	}
}