using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public bool RememberMe { get; set; }

        public string returnUrl { get; set; }
    }
}
