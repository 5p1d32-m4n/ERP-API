using STG_ERP.Models.Projects.Proposals;

namespace STG_ERP.Models.Projects.Proposals
{
    public class DisciplineDrawings
    {
        public int Id { get; set; }
        public int DrawingId { get; set; }
        public int DisciplineId { get; set; } // Reference to the new MONOLITHICCK DisciplinePercent Model
        public int SubDisciplineId { get; set; }
        public string DrawingCategory { get; set; }
        public string DrawingPageNumber { get; set; }
        public string DrawingDescription { get; set; }
        public decimal? DrawingCost { get; set; }
        public List<AEDrawing> DrawingOptions { get; set; } = new List<AEDrawing>();
    }
}