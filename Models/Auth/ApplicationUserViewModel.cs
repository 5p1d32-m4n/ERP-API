using STG_ERP.Models.Assets;
using STG_ERP.Models.Business;

namespace STG_ERP.Models.Auth
{
	public class ApplicationUserViewModel
	{
		public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

		public string AlertMessage { get; set; }
	}
}
