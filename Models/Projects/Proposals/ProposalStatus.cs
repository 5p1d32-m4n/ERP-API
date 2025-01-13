namespace ERP_API.Models.Projects.Proposals
{
    public class ProposalStatus
    {
        public int Id { get; set; }
        public string StatusString { get; set; }
        public int ProposalId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
