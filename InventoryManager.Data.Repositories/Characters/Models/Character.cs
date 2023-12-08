namespace InventoryManager.Data.Repositories.Characters.Models;

public class Character : Core.Models.Characters.Character
{
	public Guid UserId { get; set; }
}