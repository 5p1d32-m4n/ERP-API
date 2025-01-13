namespace STG_ERP.Models.Resources
{
	public class ResourcesViewModel
	{
		public IEnumerable<Resource> Resources { get; set; }

		public string AlertMessage { get; set; }

		public string Message { get; set; }
	}
}
