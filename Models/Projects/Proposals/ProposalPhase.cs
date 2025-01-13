namespace STG_ERP.Models.Projects.Proposals
{
	public class ProposalPhase
	{
        public int Id { get; set; }
        public int ServiceDeliverableId { get; set; }
        public int ProposalId { get; set; }
        public decimal Percentage { get; set; }
        public decimal Cost { get; set; }

        //IEnumerable<DepartmentEffort>? DepartmentEfforts { get; set; }
        //IEnumerable<Deliverable> Deliverables { get; set; }

        //Calculated methods
        //public decimal? TotalDeliverableCost => Deliverables?.Sum(d => d.TotalCost);
        public decimal? PercentageCost(decimal? ProposalCost) {
            return ProposalCost.HasValue ? Percentage * ProposalCost : null;
        }
    }
}
