namespace ERP_API.Models.Projects.Projects
{
    public class ProjectSubConsultant{
        public int Id {get; set;}
        public int ProjectId {get; set;}
        public int DeliverableId {get; set;}
        public string DeliverableName {get; set;}
        public string Name {get; set;}
        public decimal Cost {get; set;}
        public DateTime? Date {get; set;}
    }
}