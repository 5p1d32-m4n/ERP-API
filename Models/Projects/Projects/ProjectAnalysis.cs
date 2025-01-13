using System.ComponentModel.DataAnnotations;
using ERP_API.Models.Business;
using ERP_API.Models.ClientsVendors;
using ERP_API.Models.Timesheet;

namespace ERP_API.Models.Projects.Projects
{
    public class ProjectAnalysis
    {
        public ProjectAnalysis(){
        }

        public DateTime PlannedDate { get; set; }
        public decimal PlannedValue { get; set; }
        public decimal TimesheetCost { get; set; }
        public decimal SubConsultantsCost { get; set; }
        public float OfficeOverheadPercent { get; set; }
        public decimal OfficeOverheadCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal EarnedValue { get; set; }
        public decimal CPI { get; set; }
        public decimal SPI { get; set; }
        public decimal AccumulatedPlannedValue { get; set; }
        public decimal AccumulatedEarnedValue { get; set; }
        public decimal AccumulatedActualCost { get; set; }
        public decimal AccumulatedCPI { get; set; }
        public decimal AccumulatedSPI { get; set; }
    }
}