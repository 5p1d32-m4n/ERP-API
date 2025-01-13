using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using STG_ERP.Models.Business;
using System.Text.Json.Serialization;

namespace STG_ERP.Models.ClientsVendors
{
    public class ClientVendor
    {
        public int Id { get; set; }

		public string ClientType { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[Remote("ExistClientId",controller:"ClientsVendors",AdditionalFields ="Id")]
		public string ClientVendorId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		public bool Active { get; set; }
        
        public string AddressLine { get; set; }

        public string AddressLine2 { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public int TownId { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		public string State { get; set; }

		public string Zipcode { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
		public string Email { get; set; }

        public string Description { get; set; }

		public string Website { get; set; } 

        public string Specialty { get; set; }
        
        public string FaxNumber { get; set; }

        public string ContactOne { get; set; }

        [Phone]
        public string ContactOnePhone { get; set; }

        public string ContactTwo { get; set; }

        [Phone]
        public string ContactTwoPhone { get; set; }

        public Town town { get; set; }

		[JsonPropertyName("townName")]
		public string Town { get; set; }

		public IFormFile ImageFile { get; set; }

		public string ImageName { get; set; }

		public string GetImageUrl()
		{
			return $"/uploadedFiles/clientsVendors/images/{ImageName ?? "default.png"}";  // Client's image
		}

		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
