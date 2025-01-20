using ErpApi.Models.Assets;
using ErpApi.Models.Resources;
using System.ComponentModel.DataAnnotations;
using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Auth
{
	public class ApplicationUserCreateEditViewModel
	{
		public ApplicationUser User { get; set; }

		public List<string> RolesList { get; set; } // Add this property to hold roles

        public List<string> SelectedRole { get; set; }
        public List<string> AllRoles { get; set; }

		public List<string> EditRoles { get; set; }

		public string AlertMessage { get; set; }
		public List<RoleModuleViewModel> RoleModules { get; internal set; }

		public IEnumerable<BusinessResource> lstResources { get; set; }

		
		public int SelectedResourceId { get; set;   }

		public string EmailConfirmationCode { get; set; }

     
    }
}
