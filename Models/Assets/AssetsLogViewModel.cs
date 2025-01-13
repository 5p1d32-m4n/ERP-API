using Microsoft.AspNetCore.Mvc;

namespace STG_ERP.Models.Assets
{
    public class AssetsLogViewModel
    {
        public IEnumerable<AssetLog> AssetsLogs { get; set; }

        public string AlertMessage { get; set; }
    }
}
