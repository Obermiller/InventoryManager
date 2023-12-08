namespace InventoryManager.API.Models;

public class PostResultMultiple
{
	public List<Guid> Created { get; set; } = new();
	public List<string> Errors { get; set; } = new();
}