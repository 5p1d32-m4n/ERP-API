using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Timesheet
{
    public class TimesheetResourceConfigurationViewModel
    {
        public BusinessResource Resource { get; set; }
        public List<TimesheetPayCodes> RegularPaycodes { get; set; }
        public List<TimesheetPayCodes> ProjectPaycodes { get; set; }
        public List<BusinessResource> Approvers { get; set; }
    }
}
