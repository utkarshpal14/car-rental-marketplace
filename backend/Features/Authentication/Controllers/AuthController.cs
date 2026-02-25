using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarRentalAPI.Features.Authentication.DTOs;
using CarRentalAPI.Features.Authentication.Services;

namespace CarRentalAPI.Features.Authentication.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
     private readonly IAuthService _authService;
     public AuthController(IAuthService authService)
 {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
           var response = await _authService.RegisterAsync(request);
             return Ok(response);
    }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
             var response = await _authService.LoginAsync(request);
            return Ok(response);
            }
      catch (Exception ex)
            {
            return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest request)
        {
            try
            {
             var response = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(response);
            }
        catch (Exception ex)
            {
            return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshRequest request)
        {
            await _authService.LogoutAsync(request.RefreshToken);
            return Ok(new { message = "Logged out successfully." });
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin-test")]
        public IActionResult AdminTest()
        {
            return Ok("You are an admin.");
        }
    }
}