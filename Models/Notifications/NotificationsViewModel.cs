
namespace ErpApi.Models.Notifications
{
	public class NotificationsViewModel
	{
		public List<Notification> Notifications { get; set; }

		public List<Notification> RecentNotifications { get; set; }

		public string AlertMessage { get; set; }

		public bool EnableDelete { get; set; } = false;
	}
}
