using ERP_API.Models.Business;

namespace ERP_API.Models.Projects.Proposals
{
    public class DisciplinePercent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int ProposalId { get; set; }
        public decimal? Percentage { get; set; }
        public decimal PotentialDisciplineCost { get; set; } = 0.0M;
        public decimal? Hours { get; set; }
        public decimal HourlyRate { get; set; } = 0.0M;
        public int DisciplineId { get; set; } // Treat as null for 'sub disciplines'
        public Discipline Discipline { get; set; }
        public ProjectResource Resource { get; set; }
        public int? SubDisciplineId { get; set; }
        public string? SubDisciplineName { get; set; }
        public decimal? SubDisciplinePercentage { get; set; }
        public decimal? SubDisciplinePotCost { get; set; }

        // For Discipline Effort
        public decimal ArchitectCost { get; set; } = 0.0M; // Make this into a calculation
        public decimal ArchitectTotalHours { get; set; } = 0.0M;
        public decimal ArchitectPercent { get; set; } = 0.0M;
        public decimal ArchitectRate { get; set; } = 0.0M;
        public decimal DrafterCost { get; set; } = 0.0M; // Make this into a calculation 
        public decimal DrafterTotalHours { get; set; } = 0.0M;
        public decimal DrafterPercent { get; set; } = 0.0M;
        public decimal DrafterRate { get; set; } = 0.0M;
        public List<Discipline> Disciplines { get; set; }
        public List<ProjectResource> Resources { get; set; } = new List<ProjectResource>();
        public List<AEDrawing> Drawings { get; set; } = new List<AEDrawing>();
        public DisciplinePercent()
        {
            Disciplines = new List<Discipline>();
            Resources = new List<ProjectResource>();
            Drawings = new List<AEDrawing>(); // Ensure Drawings is never null
        }


        public decimal? CalcPotentialDisciplineCost(decimal? potentialProposalCost)
        {
            decimal? percent = Percentage / 100;
            return percent * potentialProposalCost;
        }

        public decimal? PotentialHrs(decimal? potentialProposalCost, decimal? potentialHrlRate)
        {
            decimal? potentialDiscCost = CalcPotentialDisciplineCost(potentialProposalCost);
            if (potentialDiscCost.HasValue && potentialHrlRate.HasValue && potentialHrlRate != 0)
            {
                return potentialDiscCost / potentialHrlRate;
            }
            else
            {
                return null; // Handle division by zero or null values
            }
        }
    }
}