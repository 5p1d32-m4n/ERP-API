using STG_ERP.Models.Assets;
using STG_ERP.Models.Business;

namespace STG_ERP.Models.Auth
{
    public class AccountHomeViewModel
    {
		public int AdministrationUsers { get; set; } 
		public int AssetsUsers { get; set; } 
		public int ClientsUsers { get; set; } 
		public int ProjectsUsers { get; set; } 
		public int ResourcesUsers { get; set; } 
		public int TimesheetUsers { get; set; }
		public int ProposalsUsers { get; set; }
		public int ActiveUserCount { get; set; }
		public int InactiveUserCount { get; set; }
		public int ConfirmedEmailUserCount { get; set; }
		public int LockEnabledUserCount { get; set; }
		public string Token { get; set; }
        public Dictionary<string, int> LoginCounts { get; set; }
        public IEnumerable<UserLoginLog> UserLoginLog { get; set; }
        public IEnumerable<ApplicationUser> UserList { get; set; }
        public string AlertMessage { get; set; }
	}
}
