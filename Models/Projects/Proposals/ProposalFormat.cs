namespace ErpApi.Models.Projects.Proposals
{
	public class ProposalFormat
	{
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
