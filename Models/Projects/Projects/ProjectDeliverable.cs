
namespace ERP_API.Models.Projects.Projects
{
    public class ProjectDeliverable
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public int ProjectId { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }

        public int ServiceDeliverableyCategoryId { get; set; }
        public ServiceDeliverableCategory ServiceDeliverableCategory{ get; set; }
        
        public int ServiceDeliverableId { get; set; }
        public ServiceDeliverable ServiceDeliverable { get; set; }

        public float Percentage { get; set; } = 0.0F;
        public decimal Cost { get; set; }
        public float SubconsultantPercentage { get; set; }= 0.0F;
        public decimal SubconsultantPercentageCost { get; set; } = 0.0M;
        public decimal TotalCost { get; set; } = 0.0M;
        
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public decimal PlannedDurationHrs { get; set; } = 0.0M;
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal ActualDurationHrs { get; set; } = 0.0M;
        public float ProgressPercent { get; set; }
        public decimal EarnedValue { get; set; } //Calculated
        public bool IsSubconsultant {get; set;}

        //public bool Invoiced {get; set;}
        public string InvoicedStatus {get; set;} = "Pending";

        public decimal CalcEarnedValue(){
            var result = 0.0M;
            if(ProgressPercent > 0){
                result = TotalCost * (decimal)ProgressPercent;
            }
            return result;
        }

        public decimal CalcSubconsultantPercentageCost(){
            var result = 0.0M;
            result = Cost * (decimal)(SubconsultantPercentage);
            return result;
        }
        
        public decimal CalcTotalCost(){
            var result = Cost + SubconsultantPercentageCost;
            return result;
        }
    }
}
