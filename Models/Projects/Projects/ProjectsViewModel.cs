namespace STG_ERP.Models.Projects.Projects
{
    public class ProjectsViewModel{
        public String AlertMessage {get;set;}
        public List<Project> Projects {get;set;} = new List<Project> ();
    }
}