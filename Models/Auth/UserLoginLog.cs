namespace ErpApi.Models.Auth
{
        public class UserLoginLog
        {
            public int Id { get; set; }
            public int UserId { get; set; }  
            public DateTime LoginTime { get; set; }
            public string UserName { get; set; }
            public string ModuleName { get; set; }  
        }
}

