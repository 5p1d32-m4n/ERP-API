using ErpApi.Models.Projects.Proposals;

namespace ErpApi.Models.Projects.Proposals
{
    public class ProposalStatus
    {
        public int Id { get; set; }
        public string StatusString { get; set; }
        public int ProposalId { get; set; }
        public int StatusOptionId { get; set; }
        public DateTime DateChanged { get; set; }

        public StatusOption StatusOption { get; set; }
        public Proposal Proposal { get; set; }
    }
}
