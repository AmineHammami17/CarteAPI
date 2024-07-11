using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarteAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Token { get; set; }

        public string? Role { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireTime { get; set; }

        public string? ResetPasswordToken { get; set; }

        public DateTime? ResetPasswordExpiry { get; set; }
    }
}
