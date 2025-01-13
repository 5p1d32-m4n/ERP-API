using Microsoft.AspNetCore.Mvc.Rendering;
using ERP_API.Models.Business;
using ERP_API.Models.BusinessResources;
using ERP_API.Models.ClientsVendors;
using ERP_API.Models.Projects;


namespace ERP_API.Models.Projects.Proposals
{
    public class ProposalCreateEditViewModel
    {
        public Proposal Proposal { get; set; } = new Proposal();
        public Sector sector { get; set; }
        public ClientVendor client { get; set; }
        public IEnumerable<Town> town { get; set; }
        public IEnumerable<Proposal> Proposals { get; set; }
        public string ProposalDateString { get; set; }
        public string ProposalStatusString { get; set; }
        public string ProposalFormatString { get; set; }
        public decimal? ProposalTotal { get; set; }

        public string RecommendedProposalNum { get; set; }

        //AlertMessage
        public string alertMessage { get; set; }

        // Dropdown data
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<SectorCategory> SectorCategories { get; set; }
        public IEnumerable<ProjectType> ProjectTypes { get; set; }
        public IEnumerable<ProposalType> ProposalTypes { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public IEnumerable<Complexity> Complexities { get; set; }
        public IEnumerable<Impact> Impacts { get; set; }
        public IEnumerable<ClientVendor> Clients { get; set; }
        public List<StatusOption> StatusOptions { get; set; } = new List<StatusOption>();
        public List<ProposalFormat> FormatOptions { get; set; } = new List<ProposalFormat>();
        public IEnumerable<Phase> Phases { get; set; }
        public IEnumerable<BillingStyle> BillingStyles { get; set; }
        public IEnumerable<ServiceDeliverable> ServiceDeliverables { get; set; }
        public IEnumerable<string> UnitTypes { get; set; } = new List<string>();

        // Names from related entities


        public int ProposalId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProposalTypeName { get; set; }
        public string ProjectTypeName { get; set; }
        public string ClientName { get; set; }
        public string SectorName { get; set; }
        public string SectorCategoryName { get; set; }
        public string StatusName { get; set; }
        public string ServiceTypeName { get; set; }
        public string ComplexityName { get; set; }
        public string ImpactName { get; set; }
        public string ProposalStatus { get; set; }
        public string ProposalBillingStyle { get; set; }


        // Dynamic sections for Proposal Type Specific Data (E.g PMProposal or AEProposal)


        // For dynamic dropdowns in Resources and Additional Costs
        public IEnumerable<Title> JobTitles { get; set; }
        public List<BusinessResource> BusinessResources { get; set; } = new List<BusinessResource>();
        public List<string> ActiveAssetNames { get; set; }

        public IEnumerable<Discipline> Disciplines { get; set; } = new List<Discipline>();
        public DisciplinePercent DisciplinePercent { get; set; }
        public List<DisciplinePercent> DisciplinePercents { get; set; } = new List<DisciplinePercent>();
		public List<SubDisciplinePercent> SubDisciplinePercents { get; set; } = new List<SubDisciplinePercent>();

		public IEnumerable<Discipline> AEDisciplines { get; set; } = new List<Discipline>();
        public Discipline AEDiscipline { get; set; }
        // Stage Two Updates (Post testing in production)


    }
}
