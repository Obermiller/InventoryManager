create procedure [dbo].[usp_Inventory_GetByCharacterId]
    @characterId  uniqueidentifier
as

declare @inventoryIds   UniqueIdentifierList

insert into @inventoryIds
select Id from Inventory where CharacterId = @characterId

select i.*
from Inventory i
join @inventoryIds iIds
    on iIds.Id = i.Id

select * from Item where InventoryId in (select * from @inventoryIds)