using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpApi.Models.Business;
using ErpApi.Models.Projects;
using ErpApi.Models.Timesheet;

namespace ErpApi.Models.BusinessResources
{
	public class BusinessResource
	{
		public int Id { get; set; }
		public string ImageName { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Fullname { get; set; }
		public string Suffix { get; set; } = "";

		[Required(ErrorMessage = "This field is required")]
		public string ResourceType { get; set; }="";

		//Department
		[Required(ErrorMessage = "This field is required")]
		public int DepartmentId { get; set; }
		public Department Department { get; set; }

		public int? AEDisciplineId { get; set; }
		public AEDiscipline AEDiscipline { get; set; }
		
		public int SupervisorId { get; set; }
		public string SupervisorName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string JobTitle { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public decimal SalaryRate { get; set; } = 0.0M;
		//Options
		public bool IsDirector { get; set; }
		public bool IsSupervisor { get; set; }
		public bool IsPM { get; set; }
		public bool IsPEInTraining{ get; set; }
		public bool IsRAInTraining{ get; set; }
		
		
		//PE
		[Required(ErrorMessage = "This field is required")]
		public int EngineeringTypeId { get; set; }
		public EngineeringType EngineeringType { get; set; }
		public bool IsPE{ get; set; }
		
		public string PELicenseNumber { get; set; }
		public DateTime? PELicExpiration { get; set; }
		public string CIAPRMemberCardFileName { get; set; }
		[NotMapped]
		public IFormFile CIAPRMemberCardFile { get; set; }

		//RA
		public bool IsRA{ get; set; }
		
		public string RALicenseNumber { get; set; }
		public DateTime? RALicExpiration { get; set; }
		public string CAAPMemberCardFileName { get; set; }
		[NotMapped]
		public IFormFile CAAPMemberCardFile { get; set; }

		//Resume
		public string ResumeFileName { get; set; }
		
		[NotMapped]
		public IFormFile ResumeFile { get; set; }

		//Documents
		public List<ResourceFileDocument> Documents {get; set;} = new List<ResourceFileDocument>();

		//Timesheet
		public List<TimesheetPayCodes> AllPaycodes {get; set;} = new List<TimesheetPayCodes>();
		public List<TimesheetPayCodes> RegularPaycodes {get; set;} = new List<TimesheetPayCodes>();
		public List<TimesheetPayCodes> ProjectPaycodes {get; set;} = new List<TimesheetPayCodes>();
		public List<BusinessResource> Approvers {get; set;} = new List<BusinessResource>();

		//UR
		public int ProjectPayCodeCount { get; set; } = 0;
		public decimal OtherHours { get; set; } = 0.0M;
		public decimal ProjectHours { get; set; } = 0.0M;
		public decimal TotalHrs { get; set; } = 0.0M;
		public float URPercent { get; set; } = 0.0F;

		public bool Active { get; set; } = true;

		public string GetImageUrl()
		{
			string path = "";

			if(ImageName == null || ImageName == ""){
				path = Path.Combine("/","uploads","resources","images","default.png");
			}else{
				path = Path.Combine("/","uploads","resources",Id.ToString(),"images",ImageName);
			}

			return path;
		}

		public string GetResumeUrl()
		{
			string path = Path.Combine("/","uploads","resources",Id.ToString(),"resume",ResumeFileName);

			return path;
		}
		
	}
}