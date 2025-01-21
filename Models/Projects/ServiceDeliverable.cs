namespace ErpApi.Models.Projects{
    public class ServiceDeliverable{
        public int Id {get;set;}
        public ServiceDeliverableCategory ServiceDeliverableCategory { get; set; }
        public int ServiceDeliverableCategoryId { get; set; }
        public string Name { get; set; }
    }
}