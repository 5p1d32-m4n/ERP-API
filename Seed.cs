using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ErpApi.Models.Business;
using ErpApi.Models.ClientsVendors;
using ErpApi.Models.Projects;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Data
{
    public class Seed
    {
        private readonly ProposalDbContext _context;

        public Seed(ProposalDbContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            // Ensure the database is created
            _context.Database.EnsureCreated();

            // Look for any data already in the database.
            if (_context.Proposals.Any())
            {
                return;   // DB has been seeded
            }

            var towns = new Town[]
            {
                new Town { Name = "Town1" },
                new Town { Name = "Town2" }
            };
            _context.Towns.AddRange(towns);
            _context.SaveChanges();

            var projectTypes = new ProjectType[]
            {
                new ProjectType { Name = "ProjectType1" },
                new ProjectType { Name = "ProjectType2" }
            };
            _context.ProjectTypes.AddRange(projectTypes);
            _context.SaveChanges();

            var clients = new ClientVendor[]
            {
                new ClientVendor { 
                    ClientVendorId = "CV001",
                    ClientType = "Client",
                    AddressLine = "Address 1",
                    AddressLine2 = "Address 2",
                    Name = "Client1",
                    ContactOne = "Contact 1",
                    ContactOnePhone = "(555) 555-5555",
                    Description = "Description 1",
                    ModifiedBy = "Seed",
                    TownId = towns[0].Id,
                    CreatedBy = "Seed"
                    },
                new ClientVendor {
                    ClientVendorId = "CV002",
                    ClientType = "Client",
                    AddressLine = "Address 2",
                    Name = "Client2",
                    ContactOne = "Contact 1",
                    ContactOnePhone = "(555) 555-5555",
                    Description = "Description 2",
                    ModifiedBy = "Seed",
                    TownId = towns[1].Id,
                    CreatedBy = "Seed"
                    }
            };
            _context.ClientVendors.AddRange(clients);
            _context.SaveChanges();

            var serviceTypes = new ServiceType[]
            {
                new ServiceType { Name = "Service1" },
                new ServiceType { Name = "Service2" }
            };
            _context.ServiceTypes.AddRange(serviceTypes);
            _context.SaveChanges();

            var proposalTypes = new ProposalType[]
            {
                new ProposalType { Name = "Type1" },
                new ProposalType { Name = "Type2" }
            };
            _context.ProposalTypes.AddRange(proposalTypes);
            _context.SaveChanges();

            var complexities = new Complexity[]
            {
                new Complexity { Name = "Low" },
                new Complexity { Name = "High" }
            };
            _context.Complexities.AddRange(complexities);
            _context.SaveChanges();

            var impacts = new Impact[]
            {
                new Impact { Name = "Minor" },
                new Impact { Name = "Major" }
            };
            _context.Impacts.AddRange(impacts);
            _context.SaveChanges();

            var sectorCategories = new SectorCategory[]
            {
                new SectorCategory { Name = "Category1", Description = "Description 1" },
                new SectorCategory { Name = "Category2", Description = "Description 2" }
            };
            _context.SectorCategories.AddRange(sectorCategories);
            _context.SaveChanges();

            var sectors = new Sector[]
            {
                new Sector { Name = "Sector1", Description = "Description 1", SectorCategoryId = sectorCategories[0].Id },
                new Sector { Name = "Sector2", Description = "Description 2", SectorCategoryId = sectorCategories[1].Id }
            };
            _context.Sectors.AddRange(sectors);
            _context.SaveChanges();

            var statusOptions = new StatusOption[]
            {
                new StatusOption { Name = "Draft" },
                new StatusOption { Name = "Submitted" },
                new StatusOption { Name = "Approved" }
            };
            _context.StatusOptions.AddRange(statusOptions);
            _context.SaveChanges();
            
            var proposalFormats = new ProposalFormat[]
            {
                new ProposalFormat { Name = "Format1", ServiceTypeId = serviceTypes[0].Id },
                new ProposalFormat { Name = "Format2", ServiceTypeId = serviceTypes[1].Id }
            };
            _context.ProposalFormats.AddRange(proposalFormats);
            _context.SaveChanges();

            // Insert proposals with valid foreign key references
            var proposals = new Proposal[]
            {
                new Proposal
                {
                    ProjectName = "SeedProject1",
                    Number = "001",
                    ClientId = clients[0].Id,
                    ServiceTypeId = serviceTypes[0].Id,
                    ProposalTypeId = proposalTypes[0].Id,
                    ProjectTypeId = projectTypes[0].Id,
                    ComplexityId = complexities[0].Id,
                    ImpactId = impacts[0].Id,
                    SectorCategoryId = sectorCategories[0].Id,
                    SectorId = sectors[0].Id,
                    ProposalFormatId = proposalFormats[0].Id,
                    CreatedBy = "Seed",
                },
                new Proposal
                {
                    ProjectName = "SeedProject2",
                    Number = "002",
                    ClientId = clients[1].Id,
                    ServiceTypeId = serviceTypes[1].Id,
                    ProposalTypeId = proposalTypes[1].Id,
                    ProjectTypeId = projectTypes[1].Id,
                    ComplexityId = complexities[1].Id,
                    ImpactId = impacts[1].Id,
                    SectorCategoryId = sectorCategories[1].Id,
                    SectorId = sectors[1].Id,
                    ProposalFormatId = proposalFormats[1].Id,
                    CreatedBy = "Seed",
                }
            };
            _context.Proposals.AddRange(proposals);
            _context.SaveChanges();

            var proposalStatuses = new ProposalStatus[]
            {
                new ProposalStatus { DateChanged = DateTime.Now, ProposalId = proposals[0].Id, StatusOptionId = statusOptions[0].Id, StatusString = "Status1" },
                new ProposalStatus { DateChanged = DateTime.Now, ProposalId = proposals[1].Id, StatusOptionId = statusOptions[1].Id, StatusString = "Status2" }
            };
            _context.ProposalStatuses.AddRange(proposalStatuses);
            _context.SaveChanges();
        }
    }
}