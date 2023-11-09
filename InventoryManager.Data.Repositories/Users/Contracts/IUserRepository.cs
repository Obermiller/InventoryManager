using InventoryManager.Data.Repositories.Users.Models;

namespace InventoryManager.Data.Repositories.Users.Contracts;

public interface IUserRepository
{
	User GetByEmail(string email);
}