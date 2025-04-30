using ProductCatalogAPI.Application.Models.Identity;

namespace ProductCatalogAPI.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(string id);
}
