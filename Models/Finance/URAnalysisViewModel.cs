using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Finance
{
	public class URReportViewModel{
        public List<BusinessResource> AllResources { get; set; } = new List<BusinessResource>();
        public List<BusinessResource> FilteredResources { get; set; }= new List<BusinessResource>();
    }
}