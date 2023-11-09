using InventoryManager.Data.Repositories.Users.Contracts;
using InventoryManager.Data.Repositories.Users.Models;
using InventoryManager.Logic.Users.Contracts;

namespace InventoryManager.Logic.Users;

public class UserLogic : IUserLogic
{
	private readonly IUserRepository _userRepo;

	public UserLogic(IUserRepository userRepo)
	{
		_userRepo = userRepo;
	}

	public User GetByEmail(string email) => _userRepo.GetByEmail(email);
}