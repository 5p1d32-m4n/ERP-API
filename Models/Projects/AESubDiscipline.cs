namespace ERP_API.Models.Projects
{
    public class AESubDiscipline{
        public int Id { get; set; }
        public int AEDisciplineId { get; set; }
        public AEDiscipline AEDiscipline { get; set; }
        public string Name { get; set; }
    }
}