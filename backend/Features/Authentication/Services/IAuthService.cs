using CarRentalAPI.Features.Authentication.DTOs;

namespace CarRentalAPI.Features.Authentication.Services
{
public interface IAuthService
    {
 Task<AuthResponse> RegisterAsync(RegisterRequest request);
 Task<AuthResponse> LoginAsync(LoginRequest request);
 Task<AuthResponse> RefreshTokenAsync(string refreshToken);
 Task LogoutAsync(string refreshToken);
    }
}