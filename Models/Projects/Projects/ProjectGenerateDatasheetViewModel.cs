using System.ComponentModel.DataAnnotations;
using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.BusinessResources;
using ErpApi.Models.Timesheet;

namespace ErpApi.Models.Projects.Projects
{
    public class ProjectGenerateDatasheetViewModel
    {
        public Project Project {get; set;}

        public TimesheetPayCodes TimesheetPayCode { get; set; }

        public List<BusinessResource> Resources {get; set;} = new List<BusinessResource>();

        public string AlertMessage {get; set;}
    }
}
