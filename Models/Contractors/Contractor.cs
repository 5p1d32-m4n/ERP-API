using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Contractors
{
	public class Contractor
	{
		//Profile Tab fields
		public int Id { get; set; }

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

		public string GetFullName()
		{
			return String.Join(" ", FirstName, MiddleName, LastName);
		}

		[Required(ErrorMessage = "This field is required")]
		[RegularExpression(@"^\d{9}$", ErrorMessage = "Value must be 9 digits.")]
        [Remote("ExistSSN_EIN", controller: "Contractors", AdditionalFields = "Id")]
		public string SSN_EIN { get; set; }

		[StringLength(200, ErrorMessage = "Field is max of 200 characters")]
		public string CompanyName { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime? ContractorSince { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime? InactiveDate { get; set; }

		[Required(ErrorMessage = "This field is required")]
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
		public string PhysicalState => "Puerto Rico";

		public int PhysicalTownId { get; set; }

		public string PhysicalTown { get; set; }

		public string PhysicalZipcode { get; set; }

		//Lists
		public List<History> Historys { get; set; }

		public List<MedicalSurveillance> MedicalSurveillances { get; set; }

		public List<Compliance> Compliances { get; set; }

		public List<cEducation> Educations { get; set; }

		public List<Profession> Professions { get; set; }

		public List<cTraining> Trainings { get; set; }

		public List<Document> Documents { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }

		public Contractor()
		{
			Historys = new List<History>
			{
				new History { }
			};

			MedicalSurveillances = new List<MedicalSurveillance>
			{
				new MedicalSurveillance { }
			};

			Compliances = new List<Compliance>
			{
				new Compliance { }
			};

			Educations = new List<cEducation>
			{
				new cEducation { }
			};

			Professions = new List<Profession>
			{
				new Profession { }
			};

			Trainings = new List<cTraining>
			{
				new cTraining { }
			};

			Documents = new List<Document>
			{
                new Document { }
			};
		}
	}
}
