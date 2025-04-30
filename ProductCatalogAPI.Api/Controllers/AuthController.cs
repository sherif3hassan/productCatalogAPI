using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Application.Contracts.Identity;
using ProductCatalogAPI.Application.Models.Identity;

namespace ProductCatalogAPI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthRequest request)
    {
        var response = await _authService.Login(request);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var response = await _authService.Register(request);
        return Ok(response);
    }

}
