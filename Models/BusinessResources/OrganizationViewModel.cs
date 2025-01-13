using STG_ERP.Models.Business;

namespace STG_ERP.Models.BusinessResources{
    public class OrganizationViewModel{
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}