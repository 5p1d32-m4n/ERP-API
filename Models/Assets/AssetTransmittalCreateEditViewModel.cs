namespace ERP_API.Models.Assets
{
    public class AssetTransmittalCreateEditViewModel
    {
        public AssetTransmittal AssetTransmittal { get; set; }

        public IEnumerable<Asset> ActiveAssets { get; set; }

        public AssetTransmittalItem AssetTransmittalItem { get; set; }
		public string AlertMessage { get; set; }

    }
}
