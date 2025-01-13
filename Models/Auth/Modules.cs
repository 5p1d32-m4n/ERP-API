using Microsoft.AspNetCore.Mvc;

namespace STG_ERP.Models.Auth
{
	public class Modules
	{
		public int Id { get; set; }
        [Remote(action: "VerifyModuleName", controller: "Account", AdditionalFields = "Id")]
        public string Name { get; set; }
		public string Description { get; set; }
	}
}
