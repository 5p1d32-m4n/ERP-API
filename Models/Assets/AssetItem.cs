using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Assets
{
    public class AssetItem
    {
        [Required(ErrorMessage = "This field is required")]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1,300,ErrorMessage ="Value should be between 1 and 300")]
        public int AssetQty { get; set; }

    }
}
