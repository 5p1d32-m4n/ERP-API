using System.ComponentModel.DataAnnotations;
using ERP_API.Models.Business;
using ERP_API.Models.BusinessResources;
using ERP_API.Models.ClientsVendors;

namespace ERP_API.Models.Projects.Projects
{
    public class ProjectInvoiceCreateEditViewModel
    {
        public Project Project {get; set;}

        public ProjectInvoice Invoice  {get; set;} = new ProjectInvoice();
        
        public string AlertMessage {get; set;}
        
    }
}
