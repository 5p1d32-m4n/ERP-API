namespace ERP_API.Models.Projects.Projects;
public class ProjectJobTimesheet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public ProjectUser ProjectUser {get; set; }

    public String JobCodeId {get; set;}

    public ProjectJobCode ProjectJobCode {get; set;}

    public string JobName {get; set;}
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime Date { get; set; }

    public int Duration { get; set; }

    public string FullName { get; set; }

    public decimal Hours { get; set; }

    public decimal PayRate { get; set; }

    public decimal Cost { get; set; }
}
