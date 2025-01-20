using ErpApi.Models.Business;

namespace ErpApi.Models.BusinessResources{
    public class OrganizationViewModel{
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}