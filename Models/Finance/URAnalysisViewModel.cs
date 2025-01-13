using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Finance
{
	public class URReportViewModel{
        public List<BusinessResource> AllResources { get; set; } = new List<BusinessResource>();
        public List<BusinessResource> FilteredResources { get; set; }= new List<BusinessResource>();
    }
}