namespace CarRentalAPI.Features.Authentication.DTOs
{
public class RegisterRequest
{
public string ErpId { get; set; } = string.Empty;
public string FirstName { get; set; } = string.Empty;
public string LastName { get; set; } = string.Empty;
public string Email { get; set; } = string.Empty;
public string Password { get; set; } = string.Empty;
public string Role { get; set; } = "renter";
public string? Phone { get; set; }
 }
}