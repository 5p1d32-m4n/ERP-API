using System.ComponentModel.DataAnnotations;
using ErpApi.Models.Business;
using ErpApi.Models.BusinessResources;
using ErpApi.Models.ClientsVendors;

namespace ErpApi.Models.Projects.Projects
{
    public class ProjectInvoiceCreateEditViewModel
    {
        public Project Project {get; set;}

        public ProjectInvoice Invoice  {get; set;} = new ProjectInvoice();
        
        public string AlertMessage {get; set;}
        
    }
}
