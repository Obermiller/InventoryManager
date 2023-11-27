using DapperExtensions;
using InventoryManager.Data.Repositories.Users.Contracts;
using InventoryManager.Data.Repositories.Users.Models;
using Microsoft.Extensions.Configuration;

namespace InventoryManager.Data.Repositories.Users;

public class UserRepository : SqlConnection, IUserRepository
{
	public UserRepository(IConfiguration config)
		: base(config) { }
	
	public User GetByEmail(string email)
	{
		using var conn = CreateConnection();

		var user = conn.Get<User>(new { Email = email });

		return user;
	}
}