using STG_ERP.Models.Projects.Projects;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetPayCodeViewModel
    {
        public string Name { get; set; }
		public int ResourceId { get; set; }
        public List<int> SelectedPayCodeIds { get; set; }
        public List<int> PayCodeList { get; set; }
		public List<TimesheetPayCodes> PayCodes { get; set; }
		public TimesheetPayCodes PayCode { get; set; }
		public ProjectsViewModel ProjectsViewModel { get; set; }
        public string alertMessage { get; set; }
    }
}
