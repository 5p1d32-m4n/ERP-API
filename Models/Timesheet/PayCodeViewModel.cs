using STG_ERP.Models.Projects.Projects;
using STG_ERP.Models.Resources;

namespace STG_ERP.Models.Timesheet
{
    public class PayCodeViewModel
    {
        public string Name { get; set; }
		public int ResourceId { get; set; }
        public List<int> SelectedPayCodeIds { get; set; }
        public List<int> PayCodeList { get; set; }
		public List<PayCode> PayCodes { get; set; }
		public PayCode PayCode { get; set; }
		public ProjectsViewModel ProjectsViewModel { get; set; }
        
    }
}
