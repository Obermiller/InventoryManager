using AutoMapper;
using InventoryManager.API.Areas.Items.Models;
using InventoryManager.Data.Repositories.Items.Models;

namespace InventoryManager.API.Mappings.Items;

public class ItemResponseProfile : Profile
{
	public ItemResponseProfile()
	{
		CreateMap<Item, ItemResponse>();
		
		CreateMap<ItemResponse, Item>();
	}
}