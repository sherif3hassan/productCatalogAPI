using Microsoft.AspNetCore.Identity;
using ProductCatalogAPI.Application.Contracts.Identity;
using ProductCatalogAPI.Application.Models.Identity;
using ProductCatalogAPI.Identity.Models;

namespace ProductCatalogAPI.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(user => new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        }).ToList();
    }
}