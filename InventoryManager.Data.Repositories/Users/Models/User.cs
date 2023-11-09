﻿namespace InventoryManager.Data.Repositories.Users.Models;

public class User
{
	public Guid Id { get; set; }
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}