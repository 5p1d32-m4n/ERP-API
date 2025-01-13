using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace STG_ERP.Models.Contractors
{
	public class cEducation
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		[StringLength(50, ErrorMessage = "Max of 50 characters")]
		public string Type { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string Description { get; set; }

		public string AttachmentName { get; set; }

		public IFormFile Attachment { get; set; }

		public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
