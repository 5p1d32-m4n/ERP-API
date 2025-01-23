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
        public DbSet<Proposal> Proposals { get; set; } = null;
        public DbSet<ProposalType> ProposalTypes { get; set; }= null;
        public DbSet<ProposalPhase> ProposalPhases { get; set; }= null;
        public DbSet<ProjectType> ProjectTypes { get; set; }= null;
        public DbSet<ServiceType> ServiceTypes { get; set; }= null;
        public DbSet<Complexity> Complexities { get; set; }= null;
        public DbSet<Impact> Impacts { get; set; }= null;
        public DbSet<Sector> Sectors { get; set; }= null;
        public DbSet<SectorCategory> SectorCategories { get; set; }= null;
        public DbSet<ProposalStatus> ProposalStatuses { get; set; }= null;
        public DbSet<StatusOption> StatusOptions { get; set; }= null;
        public DbSet<ProposalFormat> ProposalFormats { get; set; }= null;
        public DbSet<ProjectResource> ProposalResources { get; set; }= null;
        public DbSet<AdditionalCost> ProposalAdditionalCosts { get; set; }= null;
        public DbSet<Project> Projects { get; set; }= null;
        public DbSet<ProjectDeliverable> ProjectDeliverables { get; set; }= null;
        public DbSet<ProjectInvoice> ProjectInvoices { get; set; }= null;
        public DbSet<ProjectInvoiceDetail> ProjectInvoiceDetails { get; set; }= null;
        public DbSet<ProjectSubConsultant> ProjectSubConsultants { get; set; }= null;
        public DbSet<ProjectResource> ProjectResources { get; set; }= null;
        public DbSet<ServiceDeliverable> ServiceDeliverables { get; set; }= null;
        public DbSet<ServiceDeliverableCategory> ServiceDeliverableCategories { get; set; }= null;
        public DbSet<ProposalDisciplinePercentDrawing> ProposalDisciplinePercentDrawings { get; set; }= null;
        public DbSet<SubDisciplinePercent> SubDisciplinePercents { get; internal set; }= null;
        public DbSet<ClientVendor> ClientVendors { get; set; }= null;
        public DbSet<Town> Towns { get; set; }= null;

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
                .HasOne(p => p.Sector)
                .WithMany()
                .HasForeignKey(p => p.SectorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.ProposalFormat)
                .WithMany()
                .HasForeignKey(p => p.ProposalFormatId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure ProposalPhase entity
            modelBuilder.Entity<ProposalPhase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Percentage).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Cost).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Proposal)
                      .WithMany(p => p.ProposalPhases)
                      .HasForeignKey(e => e.ProposalId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.ServiceDeliverable)
                      .WithMany()
                      .HasForeignKey(e => e.ServiceDeliverableId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure ProposalDisciplinePercentDrawing entity
            modelBuilder.Entity<ProposalDisciplinePercentDrawing>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DrawingCategory).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DrawingPageNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DrawingDescription).HasMaxLength(500);
                entity.Property(e => e.DrawingCost).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.AEDrawing)
                      .WithMany()
                      .HasForeignKey(e => e.AEDrawingId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SubDisciplinePercent)
                      .WithMany(s => s.Drawings)
                      .HasForeignKey(e => e.SubDisciplinePercentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

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

            // ClientVendor relationships
            modelBuilder.Entity<ClientVendor>()
                .HasOne(cv => cv.Town)
                .WithMany()
                .HasForeignKey(cv => cv.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProposalStatus relationships
            modelBuilder.Entity<ProposalStatus>()
                .HasOne(ps => ps.Proposal)
                .WithMany(p => p.ProposalStatuses)
                .HasForeignKey(ps => ps.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProposalStatus>()
                .HasOne(ps => ps.StatusOption)
                .WithMany()
                .HasForeignKey(ps => ps.StatusOptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}