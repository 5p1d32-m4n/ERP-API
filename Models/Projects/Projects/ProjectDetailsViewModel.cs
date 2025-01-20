using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Projects.Projects
{
    public class ProjectDetailsViewModel{
        public Project Project {get;set;}
        public List<BusinessResource> Resources {get;set;} = new List<BusinessResource> ();
    }
}