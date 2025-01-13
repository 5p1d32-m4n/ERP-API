
namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectDeliverableMonthData
    {
        public DateTime DateRange {get; set;}
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public string MonthNameAbbr { get; set; }
        public decimal TSheetHrs { get; set; }
        public decimal TSheetCost { get; set; }
        public decimal SubConsultantsCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal DeliverableCost { get; set; }
        public decimal PlannedValue { get; set; }
        public decimal EarnedValue { get; set; }
    }
}
