using System.ComponentModel.DataAnnotations;
using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;

namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectInvoiceDetail
    {
        public int Id { get; set; }
        public int ProjectInvoiceId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Deliverable { get; set; }
        public int DeliverableId { get; set; }
        public float DeliverablePercent { get; set; }
        public decimal DeliverableTotalCost { get; set; } = 0.0M;
        public bool IsSubconsultant { get; set; }
        public float SubconsultantPercentage { get; set; }= 0.0F;
        public decimal SubconsultantPercentageCost { get; set; } = 0.0M;
        public decimal Amount { get; set; }
    }
}
