using ERP_API.Models.Business;
using ERP_API.Models.ClientsVendors;
using ERP_API.Models.Projects;
using ERP_API.Models.Projects.Projects;
using ERP_API.Models.Projects.Proposals;
using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Interfaces;

public interface IProposalRepository
{
    Task<IEnumerable<Proposal>> GetAllProposalsAsync();
        Task<Proposal> GetProposalByIdAsync(int id);
        Task<int> InsertProposalAsync(Proposal proposal);
        Task<bool> UpdateProposalAsync(Proposal proposal);
        Task<bool> DeleteProposalAsync(int id);

        Task<IEnumerable<ProposalType>> GetProposalTypesAsync();
        Task<IEnumerable<ProjectType>> GetProjectTypesAsync();
        Task<IEnumerable<ServiceType>> GetServiceTypesAsync();
        Task<IEnumerable<Complexity>> GetComplexitiesAsync();
        Task<IEnumerable<Impact>> GetImpactsAsync();
        Task<IEnumerable<Sector>> GetSectorsAsync();
        Task<IEnumerable<SectorCategory>> GetSectorCategoriesAsync();
        Task<IEnumerable<ProposalStatus>> GetProposalStatusesAsync();
        Task<IEnumerable<StatusOption>> GetStatusOptionsAsync();
        Task<IEnumerable<ProposalFormat>> GetProposalFormatsAsync();
        Task<IEnumerable<ProjectResource>> GetProposalResourcesAsync();
        Task<IEnumerable<AdditionalCost>> GetProposalAdditionalCostsAsync();
        Task<IEnumerable<ProjectDeliverable>> GetProposalDeliverablesAsync();
        Task<IEnumerable<Phase>> GetPhasesAsync();
        Task<IEnumerable<DisciplinePercent>> GetDisciplinePercentsAsync();
        Task<IEnumerable<SubDisciplinePercent>> GetSubDisciplinePercentsAsync();
        Task<IEnumerable<BillingStyle>> GetBillingStylesAsync();
        Task<IEnumerable<ClientVendor>> GetClientsVendorsAsync();
        Task<IEnumerable<ProposalPhase>> GetProposalPhasesAsync();

        Task<IEnumerable<Proposal>> GetProposalsByClientIdAsync(int clientId);
        Task<IEnumerable<Proposal>> GetProposalsByStatusAsync(string status);
        Task<IEnumerable<Proposal>> GetProposalsByServiceTypeAsync(int serviceTypeId);
        Task<IEnumerable<Proposal>> GetProposalsBySectorAsync(int sectorId);

        Task<int> GetProposalCountByStatusAsync(string status);
        Task<decimal> GetTotalProposalCostAsync(int proposalId);
        Task<Dictionary<string, int>> GetProposalCountByTypeAsync();
}