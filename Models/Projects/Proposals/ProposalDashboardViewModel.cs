
using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;
using STG_ERP.Models.Projects.Projects;
using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Projects.Proposals
{
    public class ProposalDashboardViewModel
    {
        public int TotalProposals { get; set; }
        public int ApprovedProposals { get; set; }
        public int GeneratedProposals { get; set; }
        public List<Proposal> Proposals { get; set; } = new List<Proposal>();
        public Dictionary<string, int> ProposalsByType { get; set; }
        public Dictionary<string, decimal> SectorEarnings { get; set; }
        public Dictionary<string, decimal> ComplexityVsCost { get; set; }
        public Dictionary<string, Dictionary<string, int>> MonthlyProposalsByType { get; set; } // New addition for monthly data
        public Dictionary<string, Dictionary<string, decimal>> PMBareVsBill { get; set; }
        public Dictionary<string, decimal> Deliverables { get; set; }
        public Dictionary<string, int> SectorCategoryCounts { get; set; } // New property for sector counts
        public Dictionary<string, List<Dictionary<string, decimal>>> ResourceCommitment { get; set; }
        public Dictionary<string, int> ProjectTypeDistribution { get; set; } // Placeholder for future data
        public Dictionary<string, int> ProposalStatusCounts { get; set; }
        public List<Proposal> Last10Proposals { get; set; }  // Add this property
        public Dictionary<string, decimal> ClientBudgetAllocations { get; set; } // Key: Client Name, Value: Total Allocated Budget

        public IEnumerable<SectorCategory> SectorCategories { get; set; }
        public IEnumerable<ProposalType> ProposalTypes { get; set; }
        public IEnumerable<Title> Positions { get; set;}
        public IEnumerable<ServiceDeliverable> DeliverableOptions{ get; set; }
        public IEnumerable<Complexity> Complexities { get; set; }
        public IEnumerable<ClientVendor> ClientVendors { get; set; }
        public IEnumerable<BusinessResource> Resources { get; set; }

    }
}