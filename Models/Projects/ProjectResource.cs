using ErpApi.Models.BusinessResources;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Models.Projects
{
	public class ProjectResource
	{
		public int Id { get; set; }
		public int ProposalId { get; set; }
		public int ResourceId { get; set; }
		public BusinessResource Resource { get; set; }
		public int ProjectId { get; set; }
		//public int ServiceTypeId { get; set; }
		//public int? DesignDisciplineId { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public decimal BareRate { get; set; }
		public decimal Multiplier { get; set; }
		public decimal BillRate { get; set; }
		public int Quantity { get; set; }
		public float CommitPerc { get; set; }
		public int ProjectDuration { get; set; }
		public decimal Hours { get; set; }
		public decimal Cost { get; set; }
        public Proposal Proposal { get; set; }
        public Project Project { get; set; }

        public decimal CalcBillRate(){
			decimal result = 0.0M;
			result = BareRate * Multiplier;
			return result;
		}

		public decimal CalcResourceHours(){
			decimal result = 0.0M;
			result = ProjectDuration * (decimal)172.0 * (decimal)CommitPerc * Quantity;

			return result;
		}

		public decimal CalcResourceCost()
		{
			decimal result = 0.0M;
			result =  Quantity > 0 ? Hours/Quantity  * BillRate * Quantity: 0.0M;

			return result;
		}

		// Stage Two Updates (Post testing in production)

	}
}
