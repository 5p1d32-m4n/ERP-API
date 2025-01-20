using ErpApi.Models.BusinessResources;
using ErpApi.Models.Business;

namespace ErpApi.Models.BusinessResources
{
    public class BusinessResourceCreateEditViewModel
    {
        public BusinessResource businessResource { get; set; } 
        public IEnumerable<Department> departments { get; set; }
        public List<BusinessResource> supervisors { get; set; }
        public List<EngineeringType> engTypes { get; set; }
        public string alertMessage { get; set; }

    }
}
