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
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDeliverable> ProjectDeliverables { get; set; }
        public DbSet<ProjectInvoice> ProjectInvoices { get; set; }
        public DbSet<ProjectInvoiceDetail> ProjectInvoiceDetails { get; set; }
        public DbSet<ProjectSubConsultant> ProjectSubConsultants { get; set; }
        public DbSet<ProjectResource> ProjectResources { get; set; }
        public DbSet<ServiceDeliverable> ServiceDeliverables { get; set; }
        public DbSet<ServiceDeliverableCategory> ServiceDeliverableCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Proposal relationships
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
                .HasOne(p => p.Complexity)
                .WithMany()
                .HasForeignKey(p => p.ComplexityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Impact)
                .WithMany()
                .HasForeignKey(p => p.ImpactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.SectorCategory)
                .WithMany()
                .HasForeignKey(p => p.SectorCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalFormat)
                .WithMany()
                .HasForeignKey(p => p.ProposalFormatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalStatus)
                .WithMany()
                .HasForeignKey(p => p.ProposalStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Project relationships
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ServiceType)
                .WithMany()
                .HasForeignKey(p => p.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectType)
                .WithMany()
                .HasForeignKey(p => p.ProjectTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Complexity)
                .WithMany()
                .HasForeignKey(p => p.ComplexityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Impact)
                .WithMany()
                .HasForeignKey(p => p.ImpactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.SectorCategory)
                .WithMany()
                .HasForeignKey(p => p.SectorCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Additional relationships
            modelBuilder.Entity<ProjectDeliverable>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Deliverables)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectDeliverable>()
                .HasOne(d => d.Proposal)
                .WithMany(p => p.Deliverables)
                .HasForeignKey(d => d.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.AEDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AEDisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.AESubDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AESubDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectAEDrawing>()
                .HasOne(d => d.DesignDiscipline)
                .WithMany()
                .HasForeignKey(d => d.DesignDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<ProjectInvoice>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectInvoiceDetail>()
                .HasOne(id => id.ProjectInvoice)
                .WithMany(pi => pi.ProjectInvoiceDetails)
                .HasForeignKey(id => id.ProjectInvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectSubConsultant>()
                .HasOne(sc => sc.Project)
                .WithMany(p => p.SubConsultants)
                .HasForeignKey(sc => sc.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdditionalCost>()
                .HasOne(ac => ac.Project)
                .WithMany(p => p.AdditionalCosts)
                .HasForeignKey(ac => ac.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdditionalCost>()
                .HasOne(ac => ac.Proposal)
                .WithMany(p => p.AdditionalCosts)
                .HasForeignKey(ac => ac.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(d => d.AEDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AEDisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(d => d.AESubDiscipline)
                .WithMany()
                .HasForeignKey(d => d.AESubDisciplineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DesignDiscipline>()
                .HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ServiceDeliverable>()
                .HasOne(sd => sd.ServiceDeliverableCategory)
                .WithMany()
                .HasForeignKey(sd => sd.ServiceDeliverableCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}