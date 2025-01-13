using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Contractors
{
	public class MedicalSurveillance
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime? IssuedDate { get; set; }

		[DataType(DataType.Date)] 
		public DateTime? ExpirationDate { get; set; }

		public string AttachmentName { get; set; }

        public IFormFile Attachment { get; set; }

        public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
