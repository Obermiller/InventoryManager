namespace InventoryManager.API.Identity.Models;

public class TokenGenerationRequest
{
	public Guid UserId { get; set; }
	public string Email { get; set; } = string.Empty;
}