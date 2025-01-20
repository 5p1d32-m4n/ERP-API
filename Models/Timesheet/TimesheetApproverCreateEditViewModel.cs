using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Timesheet
{
    public class TimesheetApproverCreateEditViewModel
    {
        public IEnumerable<BusinessResource> Approvers { get; set; }

        public BusinessResource timesheetApprovers { get; set; }

        public IEnumerable<BusinessResource> lstResources { get; set; }
    }
}
