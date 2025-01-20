namespace ErpApi.Models.Assets
{
    public class AssetLog
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }

        public string ResourceId {get; set;}
        public string ResourceName { get; set; }
        public DateTime DateCreated { get; set; }
        public int Qty { get; set; }

        public string Action { get; set; }

        public DateTime CreatedDate { get; set; }

        public String CreatedBy { get; set; }

    }
}
