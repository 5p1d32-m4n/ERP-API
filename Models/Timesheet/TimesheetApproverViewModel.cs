﻿using STG_ERP.Models.BusinessResources;

namespace STG_ERP.Models.Timesheet
{
    public class TimesheetApproverViewModel
    {
        public List<BusinessResource> Approvers { get; set; }
        public List<BusinessResource> Resources { get; set; }

        public List<TimesheetEntry> PendingEntries { get; set; }
        public bool ResourcesNotFound { get; set; }
        public string alertMessage { get; set; }
    }
}
