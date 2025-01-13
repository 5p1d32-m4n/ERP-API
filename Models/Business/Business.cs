using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Business
{
	public class Business
	{
		#region Business Table
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PhysicalAddress1 { get; set; }

		public string PhysicalAddress2 { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PhysicalState { get; set; }

		public int TownId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PhysicalTown { get; set; }

		[StringLength(10, ErrorMessage = "Max of 10 digits"), Required(ErrorMessage = "This field is required")]
		public string PhysicalZipCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PrimaryPhone { get; set; }

		public string SecondaryPhone { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PostalAddressLine1 { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PostalAddressLine2 { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PostalState { get; set; }

		public int TownId2 { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string PostalTown { get; set; }

		[StringLength(10, ErrorMessage = "Max of 10 digits"), Required(ErrorMessage = "This field is required")]
		public string PostalZipCode { get; set; }

		//[emailaddress]
		public string Email { get; set; }

		public string Description { get; set; }

		//Profile Image
		public IFormFile ImageFile { get; set; }

		public string ImageName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public decimal DeliverableRate { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public float OfficeOverheadPercent { get; set; }

		public string GetImageUrl()
		{
			return $"/uploads/business/{ImageName ?? "company_logo.png"}";  // Profile's image
		}
		#endregion
	}
}
