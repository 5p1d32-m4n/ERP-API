namespace STG_ERP.Models.Projects
{
	public class ProjectResourceDetail
	{
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public int ResourceId { get; set; }
		public string Position { get; set; }
		public string Name { get; set; }
		public decimal BareRate { get; set; }
		public decimal BillRate { get; set; }
		public decimal Hours { get; set; }
	}
}
