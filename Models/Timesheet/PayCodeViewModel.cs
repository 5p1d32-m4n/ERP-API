using ErpApi.Models.Resources;
using ErpApi.Models.Projects.Projects;

namespace ErpApi.Models.Timesheet
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
