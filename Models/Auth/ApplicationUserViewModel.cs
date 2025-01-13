using ERP_API.Models.Assets;
using ERP_API.Models.Business;

namespace ERP_API.Models.Auth
{
	public class ApplicationUserViewModel
	{
		public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

		public string AlertMessage { get; set; }
	}
}
