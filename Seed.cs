using ErpApi.Data;
using ErpApi.Models.Projects;
using ErpApi.Models.Projects.Proposals;
using ErpApi.Models.Projects.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErpApi
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
            if (!_context.ServiceDeliverableCategories.Any())
            {
                var serviceDeliverableCategories = new List<ServiceDeliverableCategory>
                {
                    new ServiceDeliverableCategory { Name = "Category 1" },
                    new ServiceDeliverableCategory { Name = "Category 2" },
                    new ServiceDeliverableCategory { Name = "Category 3" }
                };

                _context.ServiceDeliverableCategories.AddRange(serviceDeliverableCategories);
            }

            if (!_context.ServiceTypes.Any())
            {
                var serviceTypes = new List<ServiceType>
                {
                    new ServiceType { Name = "Type 1" },
                    new ServiceType { Name = "Type 2" },
                    new ServiceType { Name = "Type 3" }
                };

                _context.ServiceTypes.AddRange(serviceTypes);
            }

            if (!_context.Proposals.Any())
            {
                var proposals = new List<Proposal>
                {
                    new Proposal
                    {
                        Number = "P001",
                        ProjectName = "Project 1",
                        ProposalDate = new DateTime(2023, 1, 1),
                        DateCreated = DateTime.Now,
                        CreatedBy = "Admin",
                        Description = "Description 1",
                        Duration = 12,
                        ProposalStatusId = 1,
                        ProposalTypeId = 1,
                        ProposalFormatId = 1,
                        ServiceTypeId = 1,
                        ComplexityId = 1,
                        ImpactId = 1,
                        ClientId = 1,
                        SectorId = 1,
                        SectorCategoryId = 1,
                        ProjectTypeId = 1,
                        IndirectPercentage = 10.0F,
                        IndirectCost = 1000.0M,
                        IndirectCostComment = "Indirect Cost Comment",
                        ConstructionSupportPercentage = 5.0F,
                        ConstructionSupportCost = 500.0M,
                        ConstructionSupportComment = "Construction Support Comment",
                        SupervisionWeekHrs = 40.0M,
                        SupervisionHrRate = 50.0M,
                        SupervisionCost = 2000.0M,
                        IsB2B = false,
                        B2BCost = 0.0M,
                        Total = 10000.0M,
                        EngPercentStd = 15.0F,
                        PotentialDesignFee = 1500.0M,
                        PotentialHrRate = 75.0M,
                        PotentialAECostTotal = 7500.0M
                    }
                };

                _context.Proposals.AddRange(proposals);
            }

            if (!_context.ProposalStatuses.Any())
            {
                var proposalStatuses = new List<ProposalStatus>
                {
                    new ProposalStatus { StatusString = "Draft", ProposalId = 1, StatusId = 1, DateChanged = DateTime.Now }
                };

                _context.ProposalStatuses.AddRange(proposalStatuses);
            }

            if (!_context.ProposalTypes.Any())
            {
                var proposalTypes = new List<ProposalType>
                {
                    new ProposalType { Name = "Type 1" },
                    new ProposalType { Name = "Type 2" }
                };

                _context.ProposalTypes.AddRange(proposalTypes);
            }

            if (!_context.ProposalFormats.Any())
            {
                var proposalFormats = new List<ProposalFormat>
                {
                    new ProposalFormat { Name = "Format 1", ServiceTypeId = 1 },
                    new ProposalFormat { Name = "Format 2", ServiceTypeId = 2 }
                };

                _context.ProposalFormats.AddRange(proposalFormats);
            }

            if (!_context.ProposalPhases.Any())
            {
                var proposalPhases = new List<ProposalPhase>
                {
                    new ProposalPhase { ServiceDeliverableId = 1, ProposalId = 1, Percentage = 50.0M, Cost = 5000.0M }
                };

                _context.ProposalPhases.AddRange(proposalPhases);
            }

            if (!_context.ProposalDisciplinePercentDrawings.Any())
            {
                var proposalDisciplinePercentDrawings = new List<ProposalDisciplinePercentDrawing>
                {
                    new ProposalDisciplinePercentDrawing
                    {
                        AEDrawingId = 1,
                        SubDisciplinePercentId = 1,
                        DrawingCategory = "Category 1",
                        DrawingPageNumber = "Page 1",
                        DrawingDescription = "Description 1",
                        DrawingCost = 1000.0M
                    }
                };

                _context.ProposalDisciplinePercentDrawings.AddRange(proposalDisciplinePercentDrawings);
            }

            if (!_context.StatusOptions.Any())
            {
                var statusOptions = new List<StatusOption>
                {
                    new StatusOption { Name = "Draft" },
                    new StatusOption { Name = "Submitted" },
                    new StatusOption { Name = "Approved" }
                };

                _context.StatusOptions.AddRange(statusOptions);
            }

            if (!_context.SubDisciplinePercents.Any())
            {
                var subDisciplinePercents = new List<SubDisciplinePercent>
                {
                    new SubDisciplinePercent { DisciplineId = 1, DisciplinePercentId = 1 }
                };

                _context.SubDisciplinePercents.AddRange(subDisciplinePercents);
            }

            _context.SaveChanges();
        }
    }
}