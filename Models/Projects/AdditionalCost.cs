using System.ComponentModel.DataAnnotations;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Models.Projects
{
    public class AdditionalCost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A type must be assigned to all additional costs.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; } = 1;

		[Required(ErrorMessage = "An amount cost must be assigned to all additional costs.")]
		public decimal CostPerUnit {get;set;} = 0.0M;
        public decimal TotalCost {get;set;} = 0.0M;
        
        public int ProposalId { get; set; }
        public int ProjectId { get; set; }
        public Proposal Proposal { get; set; }
        public Project Project { get; set; }

        public decimal CalcTotalCost()
		{
			decimal result = 0.0M;
			result = Quantity * CostPerUnit;
			return result;
		}
	}

}
