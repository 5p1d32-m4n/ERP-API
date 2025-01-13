using System.ComponentModel.DataAnnotations;
using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;

namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectCreateEditViewModel
    {
        public Project Project {get; set;}

        public int NextProjectId  {get; set;}
        
        public List<BusinessResource> Resources {get; set;}
        
        public IEnumerable<ClientVendor> Clients {get; set;}

        public IEnumerable<ProjectType> ProjectTypes {get; set;}

        public IEnumerable<ServiceType> ServiceTypes {get; set;}

        public IEnumerable<SectorCategory> SectorCategories {get; set;}
        
        public IEnumerable<Sector> Sectors {get; set;}

        public IEnumerable<Complexity> Complexities {get; set;}

        public IEnumerable<Impact> Impacts {get; set;}

        public IEnumerable<ServiceDeliverableCategory> ServiceDeliverablesCategories {get; set;}

        public IEnumerable<ServiceDeliverable> ServiceDeliverablesStudies{get; set;}

        public IEnumerable<ServiceDeliverable> ServiceDeliverablesDesign {get; set;}

        public IEnumerable<ServiceDeliverable> ServiceDeliverablesAdditionals {get; set;}

        public IEnumerable<AEDiscipline> AEDisciplines {get; set;}

        public IEnumerable<string> UnitTypes {get; set;}
        
        public string AlertMessage {get; set;}
        
    }
}
