using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Contractors
{
	public class cTraining
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime? Date { get; set; }

		public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
