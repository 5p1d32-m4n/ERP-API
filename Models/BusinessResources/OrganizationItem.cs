namespace ErpApi.Models.BusinessResources{
    public class OrganizationItem{
        public string id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string className { get; set; }
        public List<OrganizationItem> children { get; set; } = new List<OrganizationItem>();

    }
}