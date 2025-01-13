using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Auth
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Remote(action: "VerifyEmail", controller: "Account", AdditionalFields = "Id")]
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail address.")]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }
        public string EmailNormalized { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Remote(action: "VerifyPassword", controller: "Account", HttpMethod = "POST", ErrorMessage = "Password must contain at least one uppercase letter and have a length of 8 characters.")]
        public string PasswordHash { get; set; }

        public List<string> Roles { get; set; }

        public string Role { get; set; }

        public Boolean IsActive { get; set; }

        // New properties for lockout support
        public int AccessFailedCount { get; set; } // Tracks the number of failed access attempts

        public bool LockoutEnabled { get; set; } // Indicates if lockout is enabled for the user

        public bool TwoFactorEnabled { get;set; }    

        public bool EmailConfirmed { get; set; }

		public DateTimeOffset? LockoutEnd { get; set; } // Specifies the end of the lockout period, if set

        public DateTimeOffset? LastLogin { get; set; }
        
        public Boolean IsFirstLogin { get; set; }

		public int ResourceId { get; set; }

		public DateTime? LastPasswordChangeDate { get; set; } // New property for tracking the last password change date

        public DateTime? CreateDate { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string AuthenticatorKey { get; internal set; }

        public string TwoFactorAuthCode { get; set; }

        public string EncryptionKey { get; set; }

        public string GetImageUrl()
        {
            return $"/uploads/profile/{ImageName ?? "default.png"}";  // Client's image
        }
    }
}
