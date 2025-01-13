using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.BusinessResources
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
