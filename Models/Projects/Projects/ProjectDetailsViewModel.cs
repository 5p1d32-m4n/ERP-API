using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Projects.Projects
{
    public class ProjectDetailsViewModel{
        public Project Project {get;set;}
        public List<BusinessResource> Resources {get;set;} = new List<BusinessResource> ();
    }
}