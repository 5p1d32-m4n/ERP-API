using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Contractors
{
	public class Profession
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		public string Title { get; set; }

		public string Number { get; set; }

		[DataType(DataType.Date)]
		public DateTime? IssuedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ExpirationDate { get; set; }

		public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
