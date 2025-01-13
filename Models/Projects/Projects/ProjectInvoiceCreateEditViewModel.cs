using System.ComponentModel.DataAnnotations;
using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;

namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectInvoiceCreateEditViewModel
    {
        public Project Project {get; set;}

        public ProjectInvoice Invoice  {get; set;} = new ProjectInvoice();
        
        public string AlertMessage {get; set;}
        
    }
}
