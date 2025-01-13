using ERP_API.Models.Business;
using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.BusinessResources
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
