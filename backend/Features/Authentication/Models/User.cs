using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalAPI.Features.Authentication.Models
{
    [Table("users")]
    public class User
    {
    [Key]
  [Column("id")]
 public int Id { get; set; }

[Column("erp_id")]
 public string? ErpId { get; set; }

 [Required]
[Column("first_name")]
 public string FirstName { get; set; } = string.Empty;

 [Required]
[Column("last_name")]
public string LastName { get; set; } = string.Empty;

 [Required]
 [Column("email")]
 public string Email { get; set; } = string.Empty;

[Required]
 [Column("password_hash")]
public string PasswordHash { get; set; } = string.Empty;

 [Required]
 [Column("role")]
 public string Role { get; set; } = "renter"; // default

   [Column("phone")]
 public string? Phone { get; set; }

  [Column("is_verified")]
 public bool IsVerified { get; set; } = false;

[Column("is_active")]
 public bool IsActive { get; set; } = true;

 [Column("created_at")]
 public DateTime CreatedAt { get; set; }

[Column("updated_at")]
 public DateTime UpdatedAt { get; set; }

public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}