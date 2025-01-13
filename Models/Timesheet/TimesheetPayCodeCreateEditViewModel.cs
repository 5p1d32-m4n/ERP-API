using STG_ERP.Models.Projects.Projects;
using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetPayCodeCreateEditViewModel
    {
        public string Name { get; set; }
		public int ResourceId { get; set; }
        public List<int> SelectedPayCodeIds { get; set; }
        public List<int> PayCodeList { get; set; }
        public List<int> ApproverList { get; set; }
        public List<TimesheetPayCodes> regularPaycodes { get; set; }
        public List<TimesheetPayCodes> projectPaycodes { get; set; }
        public List<TimesheetPayCodes> PayCodes { get; set; }
        public TimesheetPayCodes PayCode { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<BusinessResource> Approvers { get; set; }
        public BusinessResource resources { get; set; }
    }
}
