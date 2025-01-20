using ErpApi.Models.Business;

namespace ErpApi.Models.BusinessResources
{
	public class BusinessResourceViewModel
	{
		public List<BusinessResource> resources { get; set; }
		public string alertMessage { get; set; }
	}
}
