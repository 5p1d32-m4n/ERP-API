namespace STG_ERP.Models.Projects.Proposals
{
	public class ProposalDisciplinePercentDrawing
	{
        public int Id { get; set; }
        public int DrawingId { get; set; } // from AEDrawings table.
        public int ProposalDisciplinePercentId { get; set; }
        public int? ProposalSubDisciplinePercentId { get; set; }
        public string DrawingCategory { get; set; }
        public string DrawingPageNumber { get; set; }
        public string DrawingDescription { get; set; }
        public decimal DrawingCost { get; set; }
        public List<AEDrawing> DrawingOptions {get; set;} = new List<AEDrawing>();
    }
}
