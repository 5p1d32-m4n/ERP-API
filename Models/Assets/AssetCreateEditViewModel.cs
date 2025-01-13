namespace STG_ERP.Models.Assets
{
    public class AssetCreateEditViewModel
    {
        public Asset Asset { get; set; } 
        public IEnumerable<AssetCategory> Categories { get; set; }

        public string AlertMessage { get; set; }

    }
}
