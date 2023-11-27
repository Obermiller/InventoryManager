namespace InventoryManager.Logic.Identity.Contracts;

public interface ITokenLogic
{
	Guid? GetUserId(string? header);
}