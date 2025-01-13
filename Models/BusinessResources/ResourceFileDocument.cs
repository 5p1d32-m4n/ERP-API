namespace STG_ERP.Models.BusinessResources{
    public class ResourceFileDocument{
        public int Id {get;set;}
        public int ResourceId {get;set;}
        public string Description { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        
    }
}