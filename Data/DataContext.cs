using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.Projects;
using ErpApi.Models.Projects.Projects;
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
        public DbSet<SubDisciplinePercent> SubDisciplinePercents { get; set; }
        public DbSet<BillingStyle> BillingStyles { get; set; }
        public DbSet<ClientVendor> ClientsVendors { get; set; }
        public DbSet<ProposalPhase> ProposalPhases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Existing tables
            modelBuilder.Entity<BillingStyle>().ToTable("BillingStyles", t => t.ExcludeFromMigrations());

            // Explicit relationships
            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ServiceType)
                .WithMany()
                .HasForeignKey(p => p.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalType)
                .WithMany()
                .HasForeignKey(p => p.ProposalTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProjectType)
                .WithMany()
                .HasForeignKey(p => p.ProjectTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.SectorCategory)
                .WithMany()
                .HasForeignKey(p => p.SectorCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Impact)
                .WithMany()
                .HasForeignKey(p => p.ImpactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Complexity)
                .WithMany()
                .HasForeignKey(p => p.ComplexityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalFormat)
                .WithMany()
                .HasForeignKey(p => p.ProposalFormatId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Project)
                .WithMany()
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<ProposalStatus>()
                .HasOne(s => s.StatusOption)
                .WithMany()
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProposalStatus>()
                .HasOne(s => s.Proposal)
                .WithMany()
                .HasForeignKey(s => s.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProposalPhase>()
                .HasOne(pp => pp.Proposal)
                .WithMany(p => p.ProposalPhases)
                .HasForeignKey(pp => pp.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProposalPhase>()
                .HasOne(pp => pp.ServiceDeliverable)
                .WithMany()
                .HasForeignKey(pp => pp.ServiceDeliverableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdditionalCost>()
                .HasOne(a => a.Proposal)
                .WithMany(p => p.AdditionalCosts)
                .HasForeignKey(a => a.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdditionalCost>()
                .HasOne(a => a.Project)
                .WithMany(p => p.AdditionalCosts)
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectDeliverable>()
                .HasOne(d => d.Proposal)
                .WithMany(p => p.Deliverables)
                .HasForeignKey(d => d.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectDeliverable>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Deliverables)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectResource>()
                .HasOne(r => r.Resource)
                .WithMany()
                .HasForeignKey(r => r.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectResource>()
                .HasOne(r => r.Project)
                .WithMany(p => p.Resources)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectResource>()
                .HasOne(r => r.Proposal)
                .WithMany(p => p.Resources)
                .HasForeignKey(r => r.ProposalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectResourceDetail>()
                .HasOne(rd => rd.Project)
                .WithMany(p => p.ResourcesDetails)
                .HasForeignKey(rd => rd.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectInvoice>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectInvoiceDetail>()
                .HasOne(id => id.ProjectInvoice)
                .WithMany(i => i.Details)
                .HasForeignKey(id => id.ProjectInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.AEDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AEDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.AESubDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AESubDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.Project)
                .WithMany(p => p.ProjectAEDrawings)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(dd => dd.AEDiscipline)
                .WithMany()
                .HasForeignKey(dd => dd.AEDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(dd => dd.AESubDiscipline)
                .WithMany()
                .HasForeignKey(dd => dd.AESubDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(dd => dd.Project)
                .WithMany(p => p.DesignDisciplines)
                .HasForeignKey(dd => dd.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProposalDisciplinePercentDrawing>()
                .HasOne(d => d.SubDisciplinePercent)
                .WithMany(s => s.Drawings)
                .HasForeignKey(d => d.SubDisciplinePercentId);
        }
    }
}
