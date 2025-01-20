using ErpApi.Models.Assets;
using ErpApi.Models.Business;

namespace ErpApi.Models.Auth
{
	public class ApplicationUserViewModel
	{
		public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

		public string AlertMessage { get; set; }
	}
}
