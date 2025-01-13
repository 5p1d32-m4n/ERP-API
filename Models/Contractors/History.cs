using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Contractors
{
	public class History
	{
		public int Id { get; set; }

		public int ContractorId { get; set; }

		public string FullName { get; set; }

		[StringLength(100, ErrorMessage = "Max of 200 characters")]
		public string Position { get; set; }

		[DataType(DataType.Date)]
		public DateTime? StartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? EndDate { get; set; }

		[Range(0.0, double.MaxValue, ErrorMessage = "Rate is not a number")]

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid dollar amount")]
        public decimal Rate { get; set; }

		[StringLength(100, ErrorMessage = "Max of 200 characters")]
		public string ClientSiteProject { get; set; }

		[StringLength(100, ErrorMessage = "Max of 200 characters")]
		public string ReportingTo { get; set; }
	}
}
