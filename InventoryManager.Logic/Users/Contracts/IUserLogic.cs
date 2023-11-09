using InventoryManager.Data.Repositories.Users.Models;

namespace InventoryManager.Logic.Users.Contracts;

public interface IUserLogic
{
	User GetByEmail(string email);
}