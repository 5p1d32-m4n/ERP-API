using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.Projects.Projects;
namespace STG_ERP.Models.Timesheet;

public class TimesheetCreateEditViewModel : Timesheet
{
    public BusinessResource Resource { get; set; }
    public bool ResourceNotFound { get; set; }
    public bool IsApprover { get; set; }
    public int PendingEntriesCount { get; set; } = 0;
    public List<ProjectDeliverable> Deliveries { get; set; }
    public List<BusinessResource> Resources { get; set; }
    public int DeliveryId { get; set; }
    public int CurrentIndex { get; set; } 
    public int TotalResources { get; set; } 
    
    public TimesheetCreateEditViewModel()
    {
        this.TimeSheetEntries = new List<TimesheetEntry>();
    }
}