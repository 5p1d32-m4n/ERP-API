
namespace ErpApi.Models.Projects.Projects
{
    public class ProjectInvoice
    {
        public int Id { get; set; }
        
        public string InvoiceNumber { get; set; }
        public Project Project { get; set; }

        public int ProjectId { get; set; }

        //public DateTime InvoiceDate { get; set; }

        //public DateTime DueDate { get; set; }
        
        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public decimal Amount { get; set; } = 0.0M;

        public decimal AmountPaid { get; set; } = 0.0M;

        public decimal AmountCummulative { get; set; } = 0.0M;

        public decimal AmountBalance { get; set; } = 0.0M; //Total - Cummulative 

        public string Status { get; set; } = "Not Paid";

        public string Comments { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<ProjectInvoiceDetail> Details { get; set; } = new List<ProjectInvoiceDetail>();

        public decimal CalcAmount(){
            var result = Details.Sum(d=>d.Amount);
			return result;
        }

        // public decimal CalcAmountCummulative(){
        //     decimal result = 0.0M;
		// 	return result;
        // }

        // public decimal CalcAmountBalance(){
        //     decimal result = 0.0M;
		// 	return result;
        // }
    }
}