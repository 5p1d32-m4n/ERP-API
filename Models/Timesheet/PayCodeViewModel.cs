using ERP_API.Models.Projects.Projects;
using ERP_API.Models.Resources;

namespace ERP_API.Models.Timesheet
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
