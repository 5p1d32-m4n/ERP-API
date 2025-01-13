using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
