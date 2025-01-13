namespace ERP_API.Models.Helpers{
    public class AuditTrail{
        public int Id { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateTime { get; set; }
    }
}