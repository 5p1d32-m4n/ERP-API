using ErpApi.Models.Projects.Proposals;
namespace ErpApi.Models.Projects.Proposals
{
    public class ProposalDisciplinePercentDrawing
    {
        public int Id { get; set; }
        public AEDrawing AEDrawing { get; set; }
        public int AEDrawingId { get; set; } // from AEDrawings table.
        public SubDisciplinePercent SubDisciplinePercent { get; set; }

        public int SubDisciplinePercentId { get; set; }
        public string DrawingCategory { get; set; }
        public string DrawingPageNumber { get; set; }
        public string DrawingDescription { get; set; }
        public decimal DrawingCost { get; set; }
        public List<AEDrawing> DrawingOptions { get; set; } = new List<AEDrawing>();
    }
}
