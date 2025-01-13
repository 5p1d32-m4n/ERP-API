using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetResourceConfigurationViewModel
    {
        public BusinessResource Resource { get; set; }
        public List<TimesheetPayCodes> RegularPaycodes { get; set; }
        public List<TimesheetPayCodes> ProjectPaycodes { get; set; }
        public List<BusinessResource> Approvers { get; set; }
    }
}
