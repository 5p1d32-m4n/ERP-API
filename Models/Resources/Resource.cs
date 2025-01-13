using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Resources 
{
	public class Resource
	{
		//Profile Tab fields
		public int Id { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public bool Active { get; set; }

		public string ImageName { get; set; }

		public IFormFile ImageFile { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[StringLength(50, ErrorMessage = "Field is max of 50 characters")]
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[StringLength(50, ErrorMessage = "Field is max of 50 characters")]
		public string LastName { get; set; }
		public string Fullname { get; set; }

		public string GetFullName()
		{
			return String.Join(" ", FirstName, MiddleName, LastName);
		}

        //[Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Value must be 9 digits.")]
        [Remote("ResourceSSN_Exists", controller: "Resources")]
        public string SSN { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime? Birthday { get; set; }

		public string Gender { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string MaritalStatus { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
		public string Email { get; set; }

		public string PrimaryPhone { get; set; }

		public string SecondaryPhone { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[StringLength(50, ErrorMessage = "Field is max of 50 characters")]
		public string EmergencyContactName { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public string EmergencyContactRelationship { get; set; }

        public string EmergencyContactPhone { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string PostalAddressLine1 { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string PostalAddressLine2 { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[StringLength(50, ErrorMessage = "Max of 50 characters")]
		public string PostalState => "Puerto Rico"; // { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public int PostalTownId { get; set; }

        public string PostalTown { get; set; }

		public string PostalZipcode { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string PhysicalAddressLine1 { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string PhysicalAddressLine2 { get; set; }

		[StringLength(50, ErrorMessage = "Max of 50 characters")]
		public string PhysicalState => "Puerto Rico"; // { get; set; }

		public int PhysicalTownId  { get; set; }

        public string PhysicalTown { get; set; }

        public string PhysicalZipcode { get; set; }

		//Employment Tab fields

		//[Required(ErrorMessage = "This field is required")]
		[StringLength(15, ErrorMessage = "Field is max of 15 characters")]
		[Remote("ExistEmpNum",controller: "Resources")]
		public string EmployeeNum { get; set; }

		public string HidEmpNum { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime? HireDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? TerminationDate { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string FLSA { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public string IsSupervisor { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public int JobResourceTypeId { get; set; }

        public string JobResourceType { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public int DepartmentId { get; set; }

        public string Department { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public int JobDisciplineId { get; set; }

        public string JobDiscipline { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public int JobTitleId { get; set; }

        public string JobTitle { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public string SupervisorId { get; set; }

		public string Supervisor { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Classification { get; set; }

		//Only if Classification equals Probation
		[DataType(DataType.Date)]
		public DateTime? ProbationStartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ProbationEndDate { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public string LaborLaw { get; set; }

		public string VehicleInsurance { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid dollar amount")]
        public decimal JobHourlyCost { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid dollar amount")]
        public decimal JobYearlyCost { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string Contract { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ContractStartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ContractEndDate { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Invalid number.")]
		public string DriverLicenseNum { get; set; }

		public int DriverLicenseCategory { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DriverLicenseExpirationDate { get; set; }

//Benefits Tab
		public string StipendCell { get; set; }

		public string StipendMedPlan { get; set; }

		public string PaternalLeave { get; set; }

		public string PersonalDay { get; set; }

		public string ChristmasBonus { get; set; }

//Training,Education, Comment Tabs
		public List<Training> Trainings { get; set; }

		public List<Education> Educations { get; set; }

		[StringLength(255, ErrorMessage = "Max of 255 characters")]
		public string Comments { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }

		//public IFormFile[] Attachment { get; set; }

		public Resource ()
		{
			Educations = new List<Education>
			{
				new Education { }
			};
			Trainings = new List<Training>
			{
				new Training { }
			};
		}
	} 
}

