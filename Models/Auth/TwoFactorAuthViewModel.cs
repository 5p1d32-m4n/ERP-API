namespace STG_ERP.Models.Auth
{
    public class TwoFactorAuthViewModel
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
    }
}
