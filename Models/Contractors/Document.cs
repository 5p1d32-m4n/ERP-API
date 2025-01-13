using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Contractors
{
	public class Document
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		public string Type { get; set; }

		public string Description { get; set; }

		public string AttachmentName { get; set; }

        public IFormFile Attachment { get; set; }

        public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
