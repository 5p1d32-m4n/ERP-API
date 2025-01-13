namespace STG_ERP.Models.Assets{
    public class AssetHomeViewModel{
        public int ItemsCount { get; set; }
        public int InventoryCount { get; set; }
        public decimal CostOnInventory { get; set; }
        public int LowStockCount { get; set; }

        public IEnumerable<AssetLog> RecentAssetsLogs {get; set;}
        public List<Asset> LowStockAssets { get; set; }
    }
}