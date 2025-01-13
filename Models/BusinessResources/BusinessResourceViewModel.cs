using ERP_API.Models.Business;

namespace ERP_API.Models.BusinessResources
{
	public class BusinessResourceViewModel
	{
		public List<BusinessResource> resources { get; set; }
		public string alertMessage { get; set; }
	}
}
