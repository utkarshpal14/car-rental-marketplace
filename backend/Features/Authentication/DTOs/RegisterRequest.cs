using System.ComponentModel.DataAnnotations;
namespace CarRentalAPI.Features.Authentication.DTOs
{
public class RegisterRequest
{
public string ErpId { get; set; } = string.Empty;
[Required]
public string FirstName { get; set; } = string.Empty;
 [Required]
public string LastName { get; set; } = string.Empty;
 [Required]
[EmailAddress]
public string Email { get; set; } = string.Empty;
 [Required]
 [MinLength(6)]
public string Password { get; set; } = string.Empty;
 [Required]
public string Role { get; set; } = "renter";
public string? Phone { get; set; }
 }
}

