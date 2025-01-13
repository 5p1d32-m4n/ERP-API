using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Projects.Projects
{
    public class ProjectAdditionalCost
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A type must be assigned to all additional costs.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }

		[Required(ErrorMessage = "An amount cost must be assigned to all additional costs.")]
		public decimal Cost {get;set;}

        public int ProposalId { get; set; } 
        
		public decimal CalcAdditionalCost()
		{
			decimal result = 0.0M;
			result = (decimal)((decimal)Quantity * Cost);
			return result;
		}
	}

}
