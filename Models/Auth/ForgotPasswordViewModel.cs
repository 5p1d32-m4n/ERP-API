using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
