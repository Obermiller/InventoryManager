namespace InventoryManager.API.Models;

public class PostResult
{
	public Guid Created { get; set; }
	public List<string> Errors { get; set; } = new();
}