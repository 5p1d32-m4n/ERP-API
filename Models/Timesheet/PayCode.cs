using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Timesheet
{
    public class PayCode
    {
        public int Id { get; set; }
		public int? ProjectId { get; set; }
		[Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
    }
}
