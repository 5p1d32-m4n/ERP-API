using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetPayCodes
    {
        public int Id { get; set; }
		public int? ProjectId { get; set; }
        public string? ProjectPositionName { get; set; }   
		[Required]
        [StringLength(20)]
        [Remote(action: "VerifyPaycode", controller: "Timesheets", AdditionalFields = "Id")]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string alertMessage { get; set; }
    }
}
