using ERP_API.Models.Business;
using ERP_API.Models.ClientsVendors;
using ERP_API.Models.Projects;
using ERP_API.Models.Projects.Projects;
using ERP_API.Models.Projects.Proposals;
using ErpApi.Models.Projects.Proposals;
using Microsoft.EntityFrameworkCore;

namespace ErpApi.Data
{
    public class ProposalDbContext : DbContext
    {
        public ProposalDbContext(DbContextOptions<ProposalDbContext> options) : base(options)
        {
        }

        // DbSet properties for each table/entity
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalType> ProposalTypes { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Complexity> Complexities { get; set; }
        public DbSet<Impact> Impacts { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SectorCategory> SectorCategories { get; set; }
        public DbSet<ProposalStatus> ProposalStatuses { get; set; }
        public DbSet<StatusOption> StatusOptions { get; set; }
        public DbSet<ProposalFormat> ProposalFormats { get; set; }
        public DbSet<ProjectResource> ProposalResources { get; set; }
        public DbSet<AdditionalCost> ProposalAdditionalCosts { get; set; }
        public DbSet<ProjectDeliverable> ProposalDeliverables { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<DisciplinePercent> DisciplinePercents { get; set; }
        public DbSet<SubDisciplinePercent> SubDisciplinePercents { get; set; }
        public DbSet<BillingStyle> BillingStyles { get; set; }
        public DbSet<ClientVendor> ClientsVendors { get; set; }
        public DbSet<ProposalPhase> ProposalPhases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Proposal entity
            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ServiceType)
                .WithMany()
                .HasForeignKey(p => p.ServiceTypeId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalType)
                .WithMany()
                .HasForeignKey(p => p.ProposalTypeId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProjectType)
                .WithMany()
                .HasForeignKey(p => p.ProjectTypeId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Complexity)
                .WithMany()
                .HasForeignKey(p => p.ComplexityId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Impact)
                .WithMany()
                .HasForeignKey(p => p.ImpactId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.SectorCategory)
                .WithMany()
                .HasForeignKey(p => p.SectorCategoryId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.BillingStyle)
                .WithMany()
                .HasForeignKey(p => p.BillingStyleId);

            modelBuilder.Entity<ProjectResource>()
                .HasOne(r => r.Resource)
                .WithMany()
                .HasForeignKey(r => r.ResourceId);

            modelBuilder.Entity<ProposalFormat>()
                .HasOne(f => f.ServiceType)
                .WithMany()
                .HasForeignKey(f => f.ServiceTypeId);

            modelBuilder.Entity<ProposalStatus>()
                .HasOne(s => s.StatusOption)
                .WithMany()
                .HasForeignKey(s => s.StatusId);

            modelBuilder.Entity<ProposalStatus>()
                .HasOne(s => s.Proposal)
                .WithMany()
                .HasForeignKey(s => s.ProposalId);

            modelBuilder.Entity<AdditionalCost>()
                .HasOne(a => a.Proposal)
                .WithMany()
                .HasForeignKey(a => a.ProposalId);

            modelBuilder.Entity<ProjectDeliverable>()
                .HasOne(d => d.Proposal)
                .WithMany()
                .HasForeignKey(d => d.ProposalId);

            modelBuilder.Entity<ProposalPhase>()
                .HasOne(pp => pp.Proposal)
                .WithMany()
                .HasForeignKey(pp => pp.ProposalId);

            modelBuilder.Entity<ProposalPhase>()
                .HasOne(pp => pp.ServiceDeliverable)
                .WithMany()
                .HasForeignKey(pp => pp.ServiceDeliverableId);

            // Configure additional entities and relationships as needed
        }
    }
}
