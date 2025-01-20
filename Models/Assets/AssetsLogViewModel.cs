using Microsoft.AspNetCore.Mvc;

namespace ErpApi.Models.Assets
{
    public class AssetsLogViewModel
    {
        public IEnumerable<AssetLog> AssetsLogs { get; set; }

        public string AlertMessage { get; set; }
    }
}
