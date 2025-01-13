
namespace ERP_API.Models.Projects.Projects
{
    public class ProjectJobTimesheetsMonthData
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public string MonthNameAbbr { get; set; }
        public decimal TSheetCost { get; set; }
        public decimal TSheetCostAcc { get; set; }
        
    }
}
