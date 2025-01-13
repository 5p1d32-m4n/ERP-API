namespace STG_ERP.Models.Auth
{
	public class ApplicationRoleViewModel
	{
		public IEnumerable<ApplicationRole> ApplicationRoles { get; set; }
		public Dictionary<string, int> UserCountsByRole { get; set; }
		public string AlertMessage { get; set; }
		public IEnumerable<ApplicationUser> users { get; set; }
		public IEnumerable<ApplicationUserRole> UserRoles { get; set; }
		public List<ApplicationUser> UsersInRole { get; set; }
	}
}
