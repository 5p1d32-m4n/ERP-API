using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace STG_ERP.Models.Auth
{
	public class ApplicationRole
	{
		public int Id { get; set; }

		[Remote(action: "VerifyRole", controller: "Account", AdditionalFields = "Id")]
		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		public string NormalizedName { get; set; }

		public int AssociatedUsers { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Description { get; set; }
		public IEnumerable<Modules> modules { get; set; }

		[Required(ErrorMessage = "Please select a module")]
		public int ModuleId { get; set; }
	}
}


