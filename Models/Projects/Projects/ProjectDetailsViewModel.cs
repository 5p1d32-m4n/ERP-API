using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectDetailsViewModel{
        public Project Project {get;set;}
        public List<BusinessResource> Resources {get;set;} = new List<BusinessResource> ();
    }
}