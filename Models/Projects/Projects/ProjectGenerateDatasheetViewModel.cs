using System.ComponentModel.DataAnnotations;
using ERP_API.Models.Business;
using ERP_API.Models.BusinessResources;
using ERP_API.Models.ClientsVendors;
using ERP_API.Models.Timesheet;

namespace ERP_API.Models.Projects.Projects
{
    public class ProjectGenerateDatasheetViewModel
    {
        public Project Project {get; set;}

        public TimesheetPayCodes TimesheetPayCode { get; set; }

        public List<BusinessResource> Resources {get; set;} = new List<BusinessResource>();

        public string AlertMessage {get; set;}
    }
}
