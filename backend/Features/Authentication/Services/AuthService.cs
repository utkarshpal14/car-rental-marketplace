using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarRentalAPI.Data;
using CarRentalAPI.Features.Authentication.DTOs;
using CarRentalAPI.Features.Authentication.Models;
using CarRentalAPI.Features.Authentication.Utils;

namespace CarRentalAPI.Features.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            AppDbContext context,
            IConfiguration configuration,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _configuration = configuration;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
 public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
                throw new Exception("Email already registered.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                ErpId = request.ErpId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = request.Role.ToLower(),
                Phone = request.Phone,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await GenerateTokensAsync(user);
        }
 public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                throw new Exception("Invalid credentials.");

       var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
                throw new Exception("Invalid credentials.");

            return await GenerateTokensAsync(user);
        }
  public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken && !rt.IsRevoked);

            if (token == null || token.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Invalid or expired refresh token.");

            return await GenerateTokensAsync(token.User!);
        }
 public async Task LogoutAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            if (token == null)
                return;

            token.IsRevoked = true;
            await _context.SaveChangesAsync();
        }
  private async Task<AuthResponse> GenerateTokensAsync(User user)
        {
            var accessToken = _jwtTokenGenerator.GenerateToken(user);
            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                 AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"]))
            };
        }
    }
}