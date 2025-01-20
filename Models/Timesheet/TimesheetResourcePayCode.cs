namespace ErpApi.Models.Timesheet
{
    public class TimesheetResourcePayCode
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int PayCodeId { get; set; }
        public string ProjectPositionName { get; set; } = "";
        public decimal BareRate { get; set; } = 0.0M;
        public decimal BillRate { get; set; } = 0.0M;
    }
}

