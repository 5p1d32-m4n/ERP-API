using ErpApi.Models.Timesheet;
using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Timesheet
{
	public class TimesheetEntries
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int PayCodeId { get; set; }

		public int TimeSheetId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int Duration { get; set; }
		public string Comments { get; set; }

		public List<TimesheetEntry> TimeSheetEntries { get; set; }

		// Propiedades para cada fecha de inicio
		public DateTime StartDateMon { get; set; }
		public DateTime StartDateTue { get; set; }
		public DateTime StartDateWed { get; set; }
		public DateTime StartDateThu { get; set; }
		public DateTime StartDateFri { get; set; }
		public DateTime StartDateSat { get; set; }
		public DateTime StartDateSun { get; set; }
		public DateTime SelectedDate { get; set; }

		public int CalculateDuration(double? hours)
		{
			return hours.HasValue ? ConvertHoursToSeconds(hours.Value) : 0;
		}

		private int ConvertHoursToSeconds(double hours)
		{
			return (int)(hours * 3600);
		}
	}
}
