using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetApproverCreateEditViewModel
    {
        public IEnumerable<BusinessResource> Approvers { get; set; }

        public BusinessResource timesheetApprovers { get; set; }

        public IEnumerable<BusinessResource> lstResources { get; set; }
    }
}
