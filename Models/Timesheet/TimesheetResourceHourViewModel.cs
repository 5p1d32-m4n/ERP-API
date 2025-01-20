using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Timesheet
{
	public class TimesheetResourceHourViewModel
	{
		public List<BusinessResource> resources { get; set; }
        public Dictionary<int, decimal> otherHours { get; set; } = new Dictionary<int, decimal>(); 
        public Dictionary<int, decimal> projectHours { get; set; } = new Dictionary<int, decimal>();
        public Dictionary<int, int> projectPayCodeCounts { get; set; } = new Dictionary<int, int>();
    }
}

