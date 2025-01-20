namespace ErpApi.Models.Projects.Projects;
public class ProjectUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FirstName {get; set;}
    
    public string LastName { get; set; }

    public string Username { get; set; }

    public string EMail { get; set; }

    public decimal PayRate { get; set; }
}
