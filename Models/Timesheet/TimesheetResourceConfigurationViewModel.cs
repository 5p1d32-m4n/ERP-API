using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Timesheet
{
    public class TimesheetResourceConfigurationViewModel
    {
        public BusinessResource Resource { get; set; }
        public List<TimesheetPayCodes> RegularPaycodes { get; set; }
        public List<TimesheetPayCodes> ProjectPaycodes { get; set; }
        public List<BusinessResource> Approvers { get; set; }
    }
}
