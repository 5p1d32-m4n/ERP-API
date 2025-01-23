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
}