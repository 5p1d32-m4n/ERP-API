using Microsoft.AspNetCore.Mvc;

namespace ERP_API.Models.Assets
{
    public class AssetsLogViewModel
    {
        public IEnumerable<AssetLog> AssetsLogs { get; set; }

        public string AlertMessage { get; set; }
    }
}
