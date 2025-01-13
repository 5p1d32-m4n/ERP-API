
using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Timesheet
{
    public class TimesheetEntry
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public BusinessResource Resource { get; set; }
        public int DateKey { get; set; }
        public DateTime EntryDate { get; set; }
        public string MonthName { get; set; }
        public int WeekOfMonth { get; set; }
        public string MonthWeekName { get; set; }
        public int PayCodeId { get; set; }
        public string PayCodeTitle { get; set; }
        public string PositionName { get; set; }
        public TimesheetPayCodes Paycode { get; set; }
        public int Duration { get; set; }
        public string Deliverable { get; set; } 

        public string DeliverableName { get; set; }

        public string ConstructionSupport { get; set; }
        public string Comments { get; set; }
        public bool Approved { get; set; }
        public int? ApproverId { get; set; }
        public string Status { get; set; }
        public string ApproverName { get; set; }
        public bool isLocked { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApproverComments { get; set; }

        public string RejectComments { get; set; }
        public decimal ProjectBareRate { get; set; } = 0.0m;
        public decimal ProjectBillRate { get; set; } = 0.0m;
        public decimal SalaryRate { get; set; } = 0.0m;
        public decimal TotalBareRate { get; set; } = 0.0m;
        public decimal TotalBillRate { get; set; } = 0.0m;
        public decimal TotalSalaryRate { get; set; } = 0.0m;
        
    }
}
