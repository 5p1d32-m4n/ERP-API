using Microsoft.AspNetCore.Mvc;

namespace STG_ERP.Models.Assets
{
    public class AssetsViewModel
    {
        public IEnumerable<Asset> Assets { get; set; }

        public IEnumerable<Asset> EHSAssets { get; set; }

        public IEnumerable<Asset> OfficeAssets { get; set; }


        public IEnumerable<AssetCategory> Categories { get; set; }

        public string AlertMessage { get; set; }
    }
}
