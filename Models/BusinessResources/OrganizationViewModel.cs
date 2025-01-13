using ERP_API.Models.Business;

namespace ERP_API.Models.BusinessResources{
    public class OrganizationViewModel{
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}