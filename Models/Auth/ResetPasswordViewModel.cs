using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Auth
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
       
        [Remote(action: "VerifyPassword", controller: "Account", HttpMethod = "POST", ErrorMessage = "Password must contain at least one uppercase letter and have a length of 8 characters.")]
        public string PasswordHash { get; set; }
       
        [Compare("PasswordHash", ErrorMessage = "The password and confirmation password do not match.")]
        //public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

       
    }
}
