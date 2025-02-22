using PMSv1_Shared.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PMSv1_Shared.Entities.UserManagement
{
    public class User : BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string ResetToken { get; set; } = string.Empty; // For password reset
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }

    public class ResetPasswordRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
