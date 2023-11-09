using InventoryManager.Data.Repositories.Users.Contracts;
using InventoryManager.Data.Repositories.Users.Models;

namespace InventoryManager.Data.Repositories.Users;

public class UserRepository : IUserRepository
{
	public User GetByEmail(string email)
	{
		return new User
		{
			Id = Guid.NewGuid(),
			Email = email,
			Password = string.Empty
		};
	}
}