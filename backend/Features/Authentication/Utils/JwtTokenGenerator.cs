using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CarRentalAPI.Features.Authentication.Models;

namespace CarRentalAPI.Features.Authentication.Utils
{
    public class JwtTokenGenerator
    {
    private readonly IConfiguration _configuration;
     public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
        var key = new SymmetricSecurityKey(
         Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

         var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
        {
       new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
       new Claim(ClaimTypes.Email, user.Email),
       new Claim(ClaimTypes.Role, user.Role)
       };
var token = new JwtSecurityToken(
issuer: _configuration["Jwt:Issuer"],
audience: _configuration["Jwt:Audience"],
claims: claims,
expires: DateTime.UtcNow.AddMinutes
(
Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
signingCredentials: credentials
 );
return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}