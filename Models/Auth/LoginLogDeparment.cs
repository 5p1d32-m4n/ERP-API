namespace STG_ERP.Models.Auth
{
    public class LoginLogDeparment
    {
        public DateTime LoginDate { get; set; }
        public int AdminLoginCount { get; set; }

        public int BothLoginCount { get; set; }
        public int OtherLoginCount { get; set; }
    }
}
