using ERP_API.Models.Business;
using ERP_API.Models.BusinessResources;
using ERP_API.Models.Auth;

namespace ERP_API.Models.Timesheet;
public class Timesheet
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public int ApprovalId { get; set; }
	public string Status { get; set; }
    public string CreatedBy { get; set; }
    public string FullName { get; set; }
    public Department Department { get; set; }
    public BusinessResource BusinessResources { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public double? TotalHours { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime SelectedDate { get; set; }
	public DateTime StartDate { get; internal set; }
	public DateTime LastUpdatedDate { get; internal set; }
	public string LastUpdatedBy { get; set; }
    public List<TimesheetEntry> TimeSheetEntries { get; set; } = new List<TimesheetEntry>();
    
}
