using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Resources
{
	public class Training
	{
		public int Id { get; set; }

		public int EmployeeId { get; set; }

		[DataType(DataType.Date)]
		public DateTime? TrainingDate { get; set; }

		[StringLength(200, ErrorMessage = "Max of 200 characters")]
		public string Title { get; set; }

		public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
