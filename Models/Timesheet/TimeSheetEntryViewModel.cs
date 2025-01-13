namespace STG_ERP.Models.Timesheet
{
    internal class TimeSheetEntryViewModel
    {
        public object ProjectId { get; set; }
        public object JobName { get; set; }
        public object MonHours { get; set; }
        public object TueHours { get; set; }
        public object WedHours { get; set; }
        public object ThuHours { get; set; }
        public object FriHours { get; set; }
        public object SatHours { get; set; }
        public object SunHours { get; set; }
        public object MonComments { get; set; }
        public object TueComments { get; set; }
        public object WedComments { get; set; }
        public object ThuComments { get; set; }
        public object FriComments { get; set; }
        public object SatComments { get; set; }
        public object SunComments { get; set; }
        public double TotalHours { get; set; }

    }
}