using ERP_API.Models.Resources;
using ERP_API.Models.Timesheet;
using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Auth
{
    public class ProfileViewModel
    {
        
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public BusinessResource Resource { get; set; }
        public IEnumerable<BusinessResource> Resources { get; set; }
        
        public TimesheetEntry UserTimeSheet { get; set; }
        public string Token { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string GetImageUrl()
        {
            return $"/uploads/profile/{ImageName ?? "default_client.png"}";  // Client's image
        }
        public string alertMessage { get; set; }
    }
}
