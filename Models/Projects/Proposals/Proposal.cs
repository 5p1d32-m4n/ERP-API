using STG_ERP.Models.Business;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.ClientsVendors;
using STG_ERP.Models.Projects.Projects;
using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Projects.Proposals
{
    public class Proposal
    {

        public Proposal()
        {
            this.DisciplinePercents = new List<DisciplinePercent>();
            this.AEDrawings = new List<ProjectAEDrawing>();

        }

        public int Id { get; set; }
        [Required(ErrorMessage = "A Proposal Number must be assigned.")]
        public string Number { get; set; }
        [Required(ErrorMessage = "A Project Name must be assigned.")]
        public string ProjectName { get; set; }
        public Nullable<DateTime> ProposalDate { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }

        //from Proposal Module
        public int ProposalStatusId { get; set; }
        public ProposalStatus ProposalStatus { get; set; }
        public int ProposalTypeId { get; set; }
        public ProposalType ProposalType { get; set; }
        public int ProposalFormatId { get; set; }
        public ProposalFormat ProposalFormat { get; set; }
        public int BillingStyleId { get; set; }
        public BillingStyle BillingStyle { get; set; }

        //from Project Module
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        //from ClientVendor, Buisness, Project Module
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ComplexityId { get; set; }
        public Complexity Complexity { get; set; }
        public int ImpactId { get; set; }
        public Impact Impact { get; set; }
        public int ClientId { get; set; }
        public ClientVendor Client { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int SectorCategoryId { get; set; }

        public SectorCategory SectorCategory { get; set; }
        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        public float IndirectPercentage { get; set; } = 0.0F;
        public decimal IndirectCost { get; set; } = 0.0M;
        public string IndirectCostComment { get; set; } = "";
        public float ConstructionSupportPercentage { get; set; } = 0.0F;
        public decimal ConstructionSupportCost { get; set; } = 0.0M;
        public string ConstructionSupportComment { get; set; } = "";
        public decimal ConstructionSupportHrRate { get; set; } = 0.0M;
        public int ConstructionSupportHrs { get; set; } = 0;
        public int ServiceDeliverableyCategoryId { get; set; }
        public decimal SupervisionWeekHrs { get; set; } = 0.0M;
        public decimal SupervisionHrRate { get; set; } = 0.0M;
        public decimal SupervisionCost {get;set;} = 0.0M; 
        public bool IsB2B { get; set; } = false;
        public decimal B2BCost { get; set; } = 0.0M;
        public decimal CalcSupervisionCost  => (SupervisionHrRate > 0 && SupervisionWeekHrs > 0) ? (SupervisionWeekHrs * (decimal)(Duration * 4.3) *  SupervisionHrRate) : 0; 


        public decimal? Total { get; set; }
        public float? EngPercentStd { get; set; }
        public decimal? PotentialDesignFee { get; set; } = 0.0M;
        public decimal PotentialHrRate { get; set; } = 0.0M;
        public decimal PotentialAECostTotal { get; set; } = 0.0M;



        // Project Management Proposal
        public List<AdditionalCost> AdditionalCosts { get; set; } = new List<AdditionalCost>();
        public List<ProjectResource> Resources { get; set; } = new List<ProjectResource>();


        // A&E Proposal
        public List<DisciplinePercent> DisciplinePercents { get; set; } = new List<DisciplinePercent>();
        public List<ProposalPhase> ProposalPhases { get; set; } = new List<ProposalPhase>();
        public List<ProjectAEDrawing> AEDrawings { get; set; }
        public List<ProjectDeliverable> Deliverables { get; set; } = new List<ProjectDeliverable>();
        public List<ServiceDeliverable> ServiceDeliverables { get; set; } = new List<ServiceDeliverable>();

        public decimal CalcTotalAdditionalCosts => AdditionalCosts?.Sum(ac => ac.CalcTotalCost()) ?? 0;
        public decimal CalcConstructionSupportCost
        {
            get
            {
                // If PotentialDesignFee is null, default to 0; ConstructionSupportPercentage is already non-nullable
                decimal potentialDesignFee = PotentialDesignFee ?? 0;
                float constructionSupportPercentage = ConstructionSupportPercentage;  // No need for null check as it's not nullable

                return potentialDesignFee * (decimal)constructionSupportPercentage;
            }
        }
        public decimal CalcConstructionSupportEstimatedHours => ConstructionSupportHrRate > 0 ? (decimal)CalcConstructionSupportCost / (decimal)ConstructionSupportHrRate : 0;
        public decimal CalcTotalResources => Resources?.Sum(r => r.CalcResourceCost()) ?? 0;
        public decimal? CalcDisciplineCost => DisciplinePercents?.Sum(dp => dp.CalcPotentialDisciplineCost(PotentialAECostTotal)) ?? 0;
        public decimal? CalcDiscHrs => DisciplinePercents?.Sum(dp => dp.PotentialHrs(PotentialAECostTotal, PotentialHrRate)) ?? 0;
        public decimal? CalcDesignHrs()
        {
            if (PotentialHrRate > 0)
            {
                return PotentialDesignFee / PotentialHrRate;
            }
            else
            {
                return 0;
            }
        }
        public decimal CalcDeliverables => Deliverables.Sum(d => d.IsSubconsultant ? d.TotalCost: d.Cost);
        public decimal CalcTotalIndirectCost => (CalcTotalAdditionalCosts + CalcTotalResources) * ((decimal)IndirectPercentage);
        public decimal CalcTotalCombinedCosts => CalcTotalResources + CalcTotalAdditionalCosts + CalcTotalIndirectCost;
        public decimal CalcTotalAECost => CalcDeliverables + ConstructionSupportCost + CalcSupervisionCost;
        public decimal CalcB2BCost(){
            try{
                // Return zero if ServiceType is null or does not match known types
                if (ServiceType == null && (ServiceTypeId != 1 && ServiceTypeId != 2))
                {
                    return 0;
                }

                // For "Project Management" or ServiceTypeId == 1, return CalcTotalCombinedCosts or 0 if invalid
                if ((ServiceType != null && ServiceType.Name == "Project Management") || ServiceTypeId == 1)
                {
                    return CalcTotalCombinedCosts * 0.04M;
                }

                // For "A&E Design" or ServiceTypeId == 2, calculate from deliverables if present
                if ((ServiceType != null && ServiceType.Name == "A&E Design") || ServiceTypeId == 2)
                {
                    // Return CalcTotalAECost only if Deliverables exist and the total cost is greater than zero
                    if ((Deliverables != null && Deliverables.Any()) || CalcTotalAECost > 0)
                    {
                        return CalcTotalAECost * 0.04M;
                    }
                }

                // Return 0 if no conditions are met
                return 0;
            }
            catch (Exception ex)
            {
                // Catch unexpected errors and log them, then return zero
                Console.WriteLine($"Unexpected error in CalcProposalTotal: {ex.Message}");
                return 0;
            }
        }
        public decimal CalcProposalTotal()
        {
            try
            {
                // Return zero if ServiceType is null or does not match known types
                if (ServiceType == null && (ServiceTypeId != 1 && ServiceTypeId != 2))
                {
                    return 0;
                }

                // For "Project Management" or ServiceTypeId == 1, return CalcTotalCombinedCosts or 0 if invalid
                if ((ServiceType != null && ServiceType.Name == "Project Management") || ServiceTypeId == 1)
                {
                    if(IsB2B){
                        return CalcTotalCombinedCosts > 0 ? (CalcTotalCombinedCosts + CalcTotalCombinedCosts * 0.04M): 0;
                    }
                    return CalcTotalCombinedCosts > 0 ? CalcTotalCombinedCosts : 0;
                }

                // For "A&E Design" or ServiceTypeId == 2, calculate from deliverables if present
                if ((ServiceType != null && ServiceType.Name == "A&E Design") || ServiceTypeId == 2)
                {
                    // Return CalcTotalAECost only if Deliverables exist and the total cost is greater than zero
                    if ((Deliverables != null && Deliverables.Any()) || CalcTotalAECost > 0)
                    {
                        if(IsB2B){

                        return CalcTotalAECost > 0 ? (CalcTotalAECost + CalcTotalAECost * 0.04M) : 0;
                        }
                        return CalcTotalAECost > 0 ? CalcTotalAECost : 0;
                    }
                }

                // Return 0 if no conditions are met
                return 0;
            }
            catch (Exception ex)
            {
                // Catch unexpected errors and log them, then return zero
                Console.WriteLine($"Unexpected error in CalcProposalTotal: {ex.Message}");
                return 0;
            }
        }
        public decimal GetArchitectPercent(Proposal proposal)
        {
            foreach (var disciplinePercent in proposal.DisciplinePercents)
            {
                if (disciplinePercent.ArchitectPercent != 0)
                {
                    return disciplinePercent.ArchitectPercent;
                }
            }
            return 0;  // Return 0 if 'ArchitectPercent' is not found in any of the 'DisciplinePercents'
        }
        public decimal GetDrafterPercent(Proposal proposal)
        {
            foreach (var disciplinePercent in proposal.DisciplinePercents)
            {
                if (disciplinePercent.DrafterPercent != 0)
                {
                    return disciplinePercent.DrafterPercent;
                }
            }
            return 0;  // Return 0 if 'DrafterPercent' is not found in any of the 'DisciplinePercents'
        }
        public decimal GetArchitectRate(Proposal proposal)
        {
            foreach (var disciplinePercent in proposal.DisciplinePercents)
            {
                if (disciplinePercent.ArchitectRate != 0)
                {
                    return disciplinePercent.ArchitectRate;
                }
            }
            return 0;  // Return 0 if 'ArchitectPercent' is not found in any of the 'DisciplinePercents'
        }
        public decimal GetDrafterRate(Proposal proposal)
        {
            foreach (var disciplinePercent in proposal.DisciplinePercents)
            {
                if (disciplinePercent.DrafterRate != 0)
                {
                    return disciplinePercent.DrafterRate;
                }
            }
            return 0;  // Return 0 if 'DrafterPercent' is not found in any of the 'DisciplinePercents'
        }

    }
}