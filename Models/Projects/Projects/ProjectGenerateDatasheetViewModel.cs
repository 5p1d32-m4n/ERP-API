using System.ComponentModel.DataAnnotations;
using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;
using STG_ERP.Models.Timesheet;

namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectGenerateDatasheetViewModel
    {
        public Project Project {get; set;}

        public TimesheetPayCodes TimesheetPayCode { get; set; }

        public List<BusinessResource> Resources {get; set;} = new List<BusinessResource>();

        public string AlertMessage {get; set;}
    }
}
