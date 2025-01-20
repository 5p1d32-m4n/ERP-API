namespace ErpApi.Models.Projects
{
    public class AEDrawingTemplate{
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public AEDiscipline AEDiscipline {get;set;}
        public int SubDisciplineId { get; set; }
        public AESubDiscipline AESubDiscipline { get; set; }
        public string PageNumber { get; set; }
        public string PageTitle { get; set; }
    }
}