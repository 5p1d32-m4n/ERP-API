using System.ComponentModel.DataAnnotations;
using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.Timesheet;

namespace ErpApi.Models.Projects.Projects
{
    public class Project
    {
        public Project()
        {
            TimesheetEntries = new List<TimesheetEntry>();
            AdditionalCosts = new List<AdditionalCost>();
        }

        public int Id { get; set; }

        public int? ProposalId { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public string Number { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public string ProjectName { get; set; }

        public Nullable<DateTime> StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime DueDate { get; set; } = DateTime.Now.AddMonths(1);

        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(minimum: 1, maximum: 9999, ErrorMessage = "Enter a valid duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int ComplexityId { get; set; }

        public Complexity Complexity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int ImpactId { get; set; }

        public Impact Impact { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int ClientId { get; set; }

        public ClientVendor Client { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int SectorCategoryId { get; set; }

        public SectorCategory SectorCategory { get; set; }
        public int SectorId { get; set; }

        public Sector Sector;

        [Required(ErrorMessage = "This field is required")]
        public int ProjectTypeId { get; set; }

        public ProjectType ProjectType { get; set; }

        public decimal ProjectBudget { get; set; } = 0.0M;

        public bool IsB2B { get; set; }
        public decimal B2BCost { get; set; } = 0.0M;

        [Required(ErrorMessage = "This field is required")]
        public decimal Total { get; set; } = 0.0M;
        public int InvoicedCount { get; set; } = 0;
        public decimal InvoicedCummulative { get; set; } = 0.0M;
        public decimal InvoicedBalance { get; set; } = 0.0M;

        public string Status { get; set; } = "Draft";

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        //PM && A&E
        public List<ProjectResource> Resources { get; set; }
        public decimal ResourcesHours { get; set; } = 0.0M;
        public decimal ResourcesCost { get; set; } = 0.0M;

        //PM
        public List<AdditionalCost> AdditionalCosts { get; set; }
        public decimal AdditionalCost { get; set; } = 0.0M;

        public decimal IndirectPercent { get; set; } = 0.0M;

        public decimal IndirectCost { get; set; } = 0.0M;

        public string IndirectCostComment { get; set; }

        //A&E
        public float EngPercentStd { get; set; } = 0.0F;

        public decimal EngDesignHrRate { get; set; } = 0.0M;

        public decimal EngDesignHrs { get; set; } = 0.0M;

        public decimal EngDesignCost { get; set; } = 0.0M;

        public decimal ConstructionSupportPercent { get; set; } = 0.0M;

        public decimal ConstructionSupportCost { get; set; } = 0.0M;

        public string ConstructionSupportComment { get; set; }

        public decimal ConstructionSupportHrRate { get; set; } = 0.0M;

        public decimal ConstructionSupportHrs { get; set; } = 0.0M;

        public decimal ConstructionSupportActualHours { get; set; } = 0.0M;

        public decimal ConstructionSupportActualCost { get; set; } = 0.0M;

        public decimal SupervisionWeekHrs { get; set; } = 0.0M;

        public decimal SupervisionHrRate { get; set; } = 0.0M;

        public decimal SupervisionCost { get; set; } = 0.0M;

        public decimal SupervisionActualHours { get; set; } = 0.0M;

        public decimal SupervisionActualCost { get; set; } = 0.0M;

        // For Datasheet
        public List<ProjectResourceDetail> ResourcesDetails { get; set; }

        // A&E
        public List<DesignDiscipline> DesignDisciplines { get; set; }
        public List<ProjectAEDrawing> ProjectAEDrawings { get; set; }

        public List<ProjectDeliverable> Deliverables { get; set; } = new List<ProjectDeliverable>();

        public List<ProjectInvoice> Invoices { get; set; } = new List<ProjectInvoice>();


        // Statistics
        public decimal SubConsultantsCost { get; set; }

        public decimal TimesheetsBareRateCost { get; set; } = 0.0M;

        public decimal TimesheetsBillRateCost { get; set; } = 0.0M;

        public decimal TimesheetProfitCost { get; set; } = 0.0M;

        public decimal TimesheetProfitPercent { get; set; } = 0.0M;

        public decimal OfficeOverheadCost { get; set; } = 0.0M;

        public float OfficeOverheadPercent { get; set; } = 0.0F;

        public decimal ActualCost { get; set; } = 0.0M;

        public decimal PlannedValue { get; set; } = 0.0M;

        public decimal ActualCostPercent { get; set; } = 0.0M;

        public decimal EstimateToCompleteCost { get; set; } = 0.0M;

        public decimal EstimateToCompletePercent { get; set; } = 0.0M;

        public decimal EarnedValueEstimated { get; set; } = 0.0M;

        public decimal EarnedValuePercentEstimated { get; set; } = 0.0M;

        public decimal EarnedValueInvoiced { get; set; } = 0.0M;

        public decimal EarnedValuePercentInvoiced { get; set; } = 0.0M;

        public decimal CostVarianceEstimated { get; set; } = 0.0M;

        public decimal CostVarianceInvoiced { get; set; } = 0.0M;

        public float CostPerformanceIndexEstimated { get; set; } = 0.0F;

        public float CostPerformanceIndexInvoiced { get; set; } = 0.0F;

        public float SchedulePerformanceIndex { get; set; } = 0.0F;

        public decimal EstimateAtCompletion { get; set; } = 0.0M;

        public decimal EstimateAtCompletionInvoiced { get; set; } = 0.0M;

        public decimal ProfitEstimated { get; set; } = 0.0M;

        public decimal ProfitInvoiced { get; set; } = 0.0M;

        public float ProfitInvoicedPercent { get; set; } = 0.0F;

        public string ProfitInvoicedAnalysis { get; set; }

        public float CompletionPercent { get; set; } = 0.0F;

        //Details
        public List<TimesheetEntry> TimesheetEntries { get; set; }

        public decimal ResourcesCostConsumed { get; set; } = 0.0M;

        public decimal ResourcesCostAvailable { get; set; } = 0.0M;

        public decimal ResourcesHoursConsumed { get; set; } = 0.0M;

        public decimal ResourcesHoursAvailable { get; set; } = 0.0M;

        //Analysis
        public decimal BusinessDeliverableRate;

        public float BusinessOfficeOverheadPercent;

        public List<ProjectAnalysis> projectAnalysis = new List<ProjectAnalysis>();

        //Calcs Invoices
        public decimal CalcInvoicedCummulative()
        {
            decimal result = Invoices.Sum(i => i.AmountCummulative);
            return result;
        }

        public decimal CalcInvoicedBalance()
        {
            decimal result = Invoices.Sum(i => i.AmountBalance);
            return result;
        }

        //Calcs PM
        public decimal CalcIndirectCost()
        {
            decimal result = 0.0M;
            result = (Resources.Sum(r => r.Cost) + AdditionalCosts.Sum(a => a.TotalCost)) * IndirectPercent;
            return result;
        }

        //Calcs A&E
        public decimal CalcEngDesignCost()
        {
            decimal result = 0.0M;
            result = ProjectBudget * (decimal)EngPercentStd;
            return result;
        }

        public decimal CalcEngDesignHrs()
        {
            decimal result = 0.0M;
            result = EngDesignCost / EngDesignHrRate;
            return result;
        }

        public decimal CalcConstructionSupportCost()
        {
            decimal result = 0.0M;
            result = EngDesignCost * ConstructionSupportPercent;
            return result;
        }

        public decimal CalcConstructionSupportHours()
        {
            decimal result = 0.0M;
            if (ConstructionSupportCost > 0 && ConstructionSupportHrRate > 0)
            {
                result = ConstructionSupportCost / ConstructionSupportHrRate;
            }
            return result;
        }

        public decimal CalcSupervisionCost()
        {
            decimal result = 0.0M;
            result = SupervisionWeekHrs * (decimal)Duration * 4.3M * SupervisionHrRate;
            return result;
        }


        //Calcs Resources & Timesheet
        public decimal CalcResourcesConsumedHours()
        {
            decimal result = 0.0M;
            result = TimesheetEntries.Sum(e => e.Duration) / 3600;
            return result;
        }

        public decimal CalcResourcesCost()
        {
            decimal result = 0.0M;
            result = Resources.Sum(r => r.Cost);
            return result;
        }

        public decimal CalcTimesheetCost()
        {
            decimal result = 0.0M;
            result = TimesheetEntries.Sum(e => e.TotalBillRate);
            return result;
        }

        public decimal CalcResourcesCostDifference()
        {
            decimal result = 0.0M;
            result = CalcResourcesCost() - CalcTimesheetCost();
            return result;
        }

        public float CalcCompletionPercent()
        {
            float result = 0.0F;
            result = Deliverables.Average(d => d.ProgressPercent);
            return result;
        }
    }
}