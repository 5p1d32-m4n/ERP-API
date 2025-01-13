namespace ERP_API.Models.Notifications
{
	public class Notification
	{
		public int Id { get; set; }
		public string UserEmail { get; set; }
		public string Module { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public DateTime NotificationDate { get; set; }
		public string LevelType { get; set; }
		public bool Acknowledge { get; set; }
		public bool Trash { get; set; }
		public bool Checkbox { get; set; }

		#region GET Functions
		public string GetBorderColor()
		{
			var color = "";

			if (this.LevelType == "High")
			{
				color = "avatar-title border-primary rounded-circle";
				//return color;
			}
			if (this.LevelType == "Medium")
			{
				color = "avatar-title border-warning rounded-circle";
				//return color;
			}
			if (this.LevelType == "Low")
			{
				color = "avatar-title border-info rounded-circle";
				//return color;
			}

			return color;
		}
		public string GetModuleIcon()
		{
			var icon = "";

			if (this.Module == "Timesheet")
			{
				icon = "ti-timer";
				//return icon;
			}
			if (this.Module == "Administration")
			{
				icon = "ti-settings";
				//return icon;
			}
			if (this.Module == "Clients")
			{
				icon = "ti-briefcase";
				//return icon;
			}
			if (this.Module == "Resources")
			{
				icon = "ti-user";
				//return icon;
			}
			if (this.Module == "Contractors")
			{
				icon = "ti-user";
				//return icon;
			}
			if (this.Module == "Projects")
			{
				icon = "ti-ruler-alt-2";
				//return icon;
			}
			if (this.Module == "Assets")
			{
				icon = "ti-layout-grid2";
				//return icon;
			}
			if (this.Module == "Proposals")
			{
				icon = "ti-layout-list-thumb-alt";
				//return icon;
			}

			return icon;
		}
		public string GetStatusColor()
		{
			var color = "";

			if (this.Acknowledge == false)
			{
				color = "fas fa-check-circle";
				//return color;
			}
			if (this.Acknowledge == true)
			{
				color = "fas fa-check-circle text-success";
				//return color;
			}

			return color;
		}
		#endregion
	}
}

