using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.Projects;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Interfaces;

public interface IProposalRepository
{
        Task<IEnumerable<Proposal>> GetAllProposalsAsync();
        Task<Proposal> GetProposalByIdAsync(int id);
        Task<int> InsertProposalAsync(Proposal proposal);
        Task<bool> UpdateProposalAsync(Proposal proposal);
        Task<bool> DeleteProposalAsync(int id);

        //Read Interfaces
        Task<IEnumerable<ProposalType>> GetProposalTypesAsync();
        Task<IEnumerable<ProjectType>> GetProjectTypesAsync();
        Task<IEnumerable<ServiceType>> GetServiceTypesAsync();
        Task<IEnumerable<Complexity>> GetComplexitiesAsync();
        Task<IEnumerable<Impact>> GetImpactsAsync();
        Task<IEnumerable<Sector>> GetSectorsAsync();
        Task<IEnumerable<SectorCategory>> GetSectorCategoriesAsync();
        Task<IEnumerable<ServiceDeliverableCategory>> GetServiceDeliverableCategoriesAsync();
        Task<IEnumerable<ProposalStatus>> GetProposalStatusesAsync();
        Task<IEnumerable<StatusOption>> GetStatusOptionsAsync();
        Task<IEnumerable<ProposalFormat>> GetProposalFormatsAsync();
        Task<IEnumerable<ProjectResource>> GetProposalResourcesAsync();
        Task<IEnumerable<AdditionalCost>> GetProposalAdditionalCostsAsync();
        Task<IEnumerable<ProjectDeliverable>> GetProposalDeliverablesAsync();
        Task<IEnumerable<Phase>> GetPhasesAsync();
        Task<IEnumerable<SubDisciplinePercent>> GetSubDisciplinePercentsAsync();
        Task<IEnumerable<BillingStyle>> GetBillingStylesAsync();
        Task<IEnumerable<ClientVendor>> GetClientsVendorsAsync();
        Task<IEnumerable<ProposalPhase>> GetProposalPhasesAsync();
        Task<IEnumerable<Proposal>> GetProposalsByClientIdAsync(int clientId);
        Task<IEnumerable<Proposal>> GetProposalsByServiceTypeAsync(int serviceTypeId);
        Task<IEnumerable<Proposal>> GetProposalsBySectorAsync(int sectorId);
        Task<decimal> GetTotalProposalCostAsync(int proposalId);
        Task<Dictionary<string, int>> GetProposalCountByTypeAsync();

        // Create Interfaces
        Task<int> InsertProposalTypeAsync(ProposalType proposalType);
        Task<int> InsertProjectTypeAsync(ProjectType projectType);
        Task<int> InsertServiceTypeAsync(ServiceType serviceType);
        Task<int> InsertComplexityAsync(Complexity complexity);
        Task<int> InsertImpactAsync(Impact impact);
        Task<int> InsertSectorAsync(Sector sector);
        Task<int> InsertSectorCategoryAsync(SectorCategory sectorCategory);
        Task<int> InsertServiceDeliverableCategoryAsync(ServiceDeliverableCategory serviceDeliverableCategory);
        Task<int> InsertProposalStatusAsync(ProposalStatus proposalStatus);
        Task<int> InsertStatusOptionAsync(StatusOption statusOption);
        Task<int> InsertProposalFormatAsync(ProposalFormat proposalFormat);
        Task<int> InsertProposalResourceAsync(ProjectResource proposalResource);
        Task<int> InsertAdditionalCostAsync(AdditionalCost additionalCost);

        // Update Interfaces
        Task<bool> UpdateProposalTypeAsync(ProposalType proposalType);
        Task<bool> UpdateProjectTypeAsync(ProjectType projectType);
        Task<bool> UpdateServiceTypeAsync(ServiceType serviceType);
        Task<bool> UpdateComplexityAsync(Complexity complexity);
        Task<bool> UpdateImpactAsync(Impact impact);
        Task<bool> UpdateSectorAsync(Sector sector);
        Task<bool> UpdateSectorCategoryAsync(SectorCategory sectorCategory);
        Task<bool> UpdateServiceDeliverableCategoryAsync(ServiceDeliverableCategory serviceDeliverableCategory);
        Task<bool> UpdateProposalStatusAsync(ProposalStatus proposalStatus);
        Task<bool> UpdateStatusOptionAsync(StatusOption statusOption);
        Task<bool> UpdateProposalFormatAsync(ProposalFormat proposalFormat);
        Task<bool> UpdateProposalResourceAsync(ProjectResource proposalResource);
        Task<bool> UpdateAdditionalCostAsync(AdditionalCost additionalCost);

        // Delete Interfaces
        Task<bool> DeleteProposalTypeAsync(int id);
        Task<bool> DeleteProjectTypeAsync(int id);
        Task<bool> DeleteServiceTypeAsync(int id);
        Task<bool> DeleteComplexityAsync(int id);
        Task<bool> DeleteImpactAsync(int id);
        Task<bool> DeleteSectorAsync(int id);
        Task<bool> DeleteSectorCategoryAsync(int id);
        Task<bool> DeleteServiceDeliverableCategoryAsync(int id);
        Task<bool> DeleteProposalStatusAsync(int id);
        Task<bool> DeleteStatusOptionAsync(int id);
        Task<bool> DeleteProposalFormatAsync(int id);
        Task<bool> DeleteProposalResourceAsync(int id);
        Task<bool> DeleteAdditionalCostAsync(int id);
}