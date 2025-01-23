using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.Projects;
using ErpApi.Models.Projects.Projects;
using ErpApi.Data;
using ErpApi.Interfaces;
using ErpApi.Models.Projects.Proposals;
using Microsoft.EntityFrameworkCore;

namespace ErpApi.Repository;

public class ProposalRepository : IProposalRepository
{
    private readonly ProposalDbContext _context;

    public ProposalRepository(ProposalDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Proposal>> GetAllProposalsAsync()
        {
            try
            {
            return await _context.Proposals.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Proposal> GetProposalByIdAsync(int id)
        {
            return await _context.Proposals.FindAsync(id) ?? null;
        }

        public async Task<int> InsertProposalAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
            return proposal.Id;
        }

        public async Task<bool> UpdateProposalAsync(Proposal proposal)
        {
            _context.Proposals.Update(proposal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProposalAsync(int id)
        {
            var proposal = await _context.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return false;
            }

            _context.Proposals.Remove(proposal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProposalType>> GetProposalTypesAsync()
        {
            return await _context.ProposalTypes.ToListAsync();
        }

        public async Task<IEnumerable<ProjectType>> GetProjectTypesAsync()
        {
            return await _context.ProjectTypes.ToListAsync();
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypesAsync()
        {
            return await _context.ServiceTypes.ToListAsync();
        }

        public async Task<IEnumerable<Complexity>> GetComplexitiesAsync()
        {
            return await _context.Complexities.ToListAsync();
        }

        public async Task<IEnumerable<Impact>> GetImpactsAsync()
        {
            return await _context.Impacts.ToListAsync();
        }

        public async Task<IEnumerable<Sector>> GetSectorsAsync()
        {
            return await _context.Sectors.ToListAsync();
        }

        public async Task<IEnumerable<SectorCategory>> GetSectorCategoriesAsync()
        {
            return await _context.SectorCategories.ToListAsync();
        }

        public async Task<IEnumerable<ServiceDeliverableCategory>> GetServiceDeliverableCategoriesAsync()
        {
            return await _context.ServiceDeliverableCategories.ToListAsync();
        }

        public async Task<IEnumerable<ProposalStatus>> GetProposalStatusesAsync()
        {
            return await _context.ProposalStatuses.ToListAsync();
        }

        public async Task<IEnumerable<StatusOption>> GetStatusOptionsAsync()
        {
            return await _context.StatusOptions.ToListAsync();
        }

        public async Task<IEnumerable<ProposalFormat>> GetProposalFormatsAsync()
        {
            return await _context.ProposalFormats.ToListAsync();
        }

        public async Task<IEnumerable<ProjectResource>> GetProposalResourcesAsync()
        {
            return await _context.ProposalResources.ToListAsync();
        }

        public async Task<IEnumerable<AdditionalCost>> GetProposalAdditionalCostsAsync()
        {
            return await _context.ProposalAdditionalCosts.ToListAsync();
        }

        public async Task<IEnumerable<ProjectDeliverable>> GetProposalDeliverablesAsync()
        {
            // return await _context.ProposalDeliverables.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Phase>> GetPhasesAsync()
        {
            // return await _context.Phases.ToListAsync();
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<SubDisciplinePercent>> GetSubDisciplinePercentsAsync()
        {
            // return await _context.SubDisciplinePercents.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BillingStyle>> GetBillingStylesAsync()
        {
            // return await _context.BillingStyles.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientVendor>> GetClientsVendorsAsync()
        {
            // return await _context.ClientsVendors.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProposalPhase>> GetProposalPhasesAsync()
        {
            // return await _context.ProposalPhases.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Proposal>> GetProposalsByClientIdAsync(int clientId)
        {
            return await _context.Proposals.Where(p => p.ClientId == clientId).ToListAsync();
        }

        // public async Task<IEnumerable<Proposal>> GetProposalsByStatusAsync(string status)
        // {
        //     return await _context.Proposals.Where(p => p.ProposalStatus.StatusString == status).ToListAsync();
        // }

        public async Task<IEnumerable<Proposal>> GetProposalsByServiceTypeAsync(int serviceTypeId)
        {
            return await _context.Proposals.Where(p => p.ServiceTypeId == serviceTypeId).ToListAsync();
        }

        public async Task<IEnumerable<Proposal>> GetProposalsBySectorAsync(int sectorId)
        {
            return await _context.Proposals.Where(p => p.SectorId == sectorId).ToListAsync();
        }

        // public async Task<int> GetProposalCountByStatusAsync(string status)
        // {
        //     return await _context.Proposals.CountAsync(p => p.ProposalStatus.StatusString == status);
        // }

        public async Task<decimal> GetTotalProposalCostAsync(int proposalId)
        {
            var proposal = await _context.Proposals.FindAsync(proposalId);
            return proposal?.CalcTotalCombinedCosts ?? 0;
        }

        public async Task<Dictionary<string, int>> GetProposalCountByTypeAsync()
        {
            return await _context.Proposals
                .GroupBy(p => p.ProposalType.Name)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Count);
        }

        // Create Methods
        public async Task<int> InsertProposalTypeAsync(ProposalType proposalType)
        {
            _context.ProposalTypes.Add(proposalType);
            await _context.SaveChangesAsync();
            return proposalType.Id;
        }

        public async Task<int> InsertProjectTypeAsync(ProjectType projectType)
        {
            _context.ProjectTypes.Add(projectType);
            await _context.SaveChangesAsync();
            return projectType.Id;
        }

        public async Task<int> InsertServiceTypeAsync(ServiceType serviceType)
        {
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();
            return serviceType.Id;
        }

        public async Task<int> InsertComplexityAsync(Complexity complexity)
        {
            _context.Complexities.Add(complexity);
            await _context.SaveChangesAsync();
            return complexity.Id;
        }

        public async Task<int> InsertImpactAsync(Impact impact)
        {
            _context.Impacts.Add(impact);
            await _context.SaveChangesAsync();
            return impact.Id;
        }

        public async Task<int> InsertSectorAsync(Sector sector)
        {
            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();
            return sector.Id;
        }

        public async Task<int> InsertSectorCategoryAsync(SectorCategory sectorCategory)
        {
            _context.SectorCategories.Add(sectorCategory);
            await _context.SaveChangesAsync();
            return sectorCategory.Id;
        }

        public async Task<int> InsertServiceDeliverableCategoryAsync(ServiceDeliverableCategory serviceDeliverableCategory)
        {
            _context.ServiceDeliverableCategories.Add(serviceDeliverableCategory);
            await _context.SaveChangesAsync();
            return serviceDeliverableCategory.Id;
        }

        public async Task<int> InsertProposalStatusAsync(ProposalStatus proposalStatus)
        {
            _context.ProposalStatuses.Add(proposalStatus);
            await _context.SaveChangesAsync();
            return proposalStatus.Id;
        }

        public async Task<int> InsertStatusOptionAsync(StatusOption statusOption)
        {
            _context.StatusOptions.Add(statusOption);
            await _context.SaveChangesAsync();
            return statusOption.Id;
        }

        public async Task<int> InsertProposalFormatAsync(ProposalFormat proposalFormat)
        {
            _context.ProposalFormats.Add(proposalFormat);
            await _context.SaveChangesAsync();
            return proposalFormat.Id;
        }

        public async Task<int> InsertProposalResourceAsync(ProjectResource proposalResource)
        {
            _context.ProjectResources.Add(proposalResource);
            await _context.SaveChangesAsync();
            return proposalResource.Id;
        }

        public async Task<int> InsertAdditionalCostAsync(AdditionalCost additionalCost)
        {
            _context.ProposalAdditionalCosts.Add(additionalCost);
            await _context.SaveChangesAsync();
            return additionalCost.Id;
        }

        // Update Methods
        public async Task<bool> UpdateProposalTypeAsync(ProposalType proposalType)
        {
            _context.ProposalTypes.Update(proposalType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProjectTypeAsync(ProjectType projectType)
        {
            _context.ProjectTypes.Update(projectType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateServiceTypeAsync(ServiceType serviceType)
        {
            _context.ServiceTypes.Update(serviceType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateComplexityAsync(Complexity complexity)
        {
            _context.Complexities.Update(complexity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateImpactAsync(Impact impact)
        {
            _context.Impacts.Update(impact);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSectorAsync(Sector sector)
        {
            _context.Sectors.Update(sector);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSectorCategoryAsync(SectorCategory sectorCategory)
        {
            _context.SectorCategories.Update(sectorCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateServiceDeliverableCategoryAsync(ServiceDeliverableCategory serviceDeliverableCategory)
        {
            _context.ServiceDeliverableCategories.Update(serviceDeliverableCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProposalStatusAsync(ProposalStatus proposalStatus)
        {
            _context.ProposalStatuses.Update(proposalStatus);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStatusOptionAsync(StatusOption statusOption)
        {
            _context.StatusOptions.Update(statusOption);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProposalFormatAsync(ProposalFormat proposalFormat)
        {
            _context.ProposalFormats.Update(proposalFormat);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProposalResourceAsync(ProjectResource proposalResource)
        {
            _context.ProjectResources.Update(proposalResource);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAdditionalCostAsync(AdditionalCost additionalCost)
        {
            _context.ProposalAdditionalCosts.Update(additionalCost);
            return await _context.SaveChangesAsync() > 0;
        }

        // Delete Methods
        public async Task<bool> DeleteProposalTypeAsync(int id)
        {
            var entity = await _context.ProposalTypes.FindAsync(id);
            if (entity == null) return false;
            _context.ProposalTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectTypeAsync(int id)
        {
            var entity = await _context.ProjectTypes.FindAsync(id);
            if (entity == null) return false;
            _context.ProjectTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteServiceTypeAsync(int id)
        {
            var entity = await _context.ServiceTypes.FindAsync(id);
            if (entity == null) return false;
            _context.ServiceTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteComplexityAsync(int id)
        {
            var entity = await _context.Complexities.FindAsync(id);
            if (entity == null) return false;
            _context.Complexities.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteImpactAsync(int id)
        {
            var entity = await _context.Impacts.FindAsync(id);
            if (entity == null) return false;
            _context.Impacts.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSectorAsync(int id)
        {
            var entity = await _context.Sectors.FindAsync(id);
            if (entity == null) return false;
            _context.Sectors.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSectorCategoryAsync(int id)
        {
            var entity = await _context.SectorCategories.FindAsync(id);
            if (entity == null) return false;
            _context.SectorCategories.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteServiceDeliverableCategoryAsync(int id)
        {
            var entity = await _context.ServiceDeliverableCategories.FindAsync(id);
            if (entity == null) return false;
            _context.ServiceDeliverableCategories.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProposalStatusAsync(int id)
        {
            var entity = await _context.ProposalStatuses.FindAsync(id);
            if (entity == null) return false;
            _context.ProposalStatuses.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStatusOptionAsync(int id)
        {
            var entity = await _context.StatusOptions.FindAsync(id);
            if (entity == null) return false;
            _context.StatusOptions.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProposalFormatAsync(int id)
        {
            var entity = await _context.ProposalFormats.FindAsync(id);
            if (entity == null) return false;
            _context.ProposalFormats.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProposalResourceAsync(int id)
        {
            var entity = await _context.ProjectResources.FindAsync(id);
            if (entity == null) return false;
            _context.ProjectResources.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAdditionalCostAsync(int id)
        {
            var entity = await _context.ProposalAdditionalCosts.FindAsync(id);
            if (entity == null) return false;
            _context.ProposalAdditionalCosts.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
}