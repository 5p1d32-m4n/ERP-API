
namespace ErpApi.Models.Projects.Projects
{
    public class ProjectJobCode
    {
        public int Id { get; set; }

        public int ProjecId { get; set; }

        public int JobCodeId { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }
    }
}
