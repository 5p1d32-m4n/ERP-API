using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
