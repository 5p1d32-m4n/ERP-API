using ErpApi.Models.BusinessResources;

namespace ErpApi.Models.Timesheet
{
    public class TimesheetReportCreateEditViewModel :  Timesheet
    {
        public List<BusinessResource> TeamResources { get; set; }
        public List<BusinessResource> Resources { get; set; }
        public Dictionary<int, List<TimesheetEntry>> GroupedTimeSheetEntries { get; set; }
        public Dictionary<int, string> ResourceNames { get; set; }
        public bool IncludeResourceId { get; set; }
        public bool IncludeDate { get; set; }
        public bool IncludeDuration { get; set; }
        public bool IncludeDeliverable { get; set; }
        public bool IncludeComments { get; set; }
        public bool IncludePayCodeTitle { get; set; }
        public bool IncludeApproverName { get; set; }
        public bool IncludeApproveDate { get; set; }
        public bool IncludeTotal { get; set; }
        public bool IncludeDailyTotal { get; set; }
        public bool IncludeImage { get; set; }
        public bool IncludePosition { get; set; }
        public bool IncludeOthersHrs { get; set; }
        public bool IncludeProjectHrs { get; set; }
        public bool IncludeTotalHrs { get; set; }
        public bool IncludeURS { get; set; }
        public bool IncludeProjectQty { get; set; }
        public TimesheetReportCreateEditViewModel()
        {
            this.TimeSheetEntries = new List<TimesheetEntry>();
        }
    }
}
