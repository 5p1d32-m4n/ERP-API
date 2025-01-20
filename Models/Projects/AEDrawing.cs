namespace ErpApi.Models.Projects
{
    public class AEDrawing
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public AEDiscipline AEDiscipline { get; set; }
        public string PageNumber { get; set; }
        public string Title { get; set; }
    }
}