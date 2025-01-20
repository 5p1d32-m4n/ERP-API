using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Timesheet
{
    public class TimesheetViewHomeModel
    {
        public int Approve { get; set; }
        public int Saved { get; set; }
        public int Submitted { get; set; }
        public string AlertMessage { get; set; }
		public IEnumerable<Timesheet> Timesheets { get; set; }
	}
}