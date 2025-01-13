using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Assets
{
	public class AssetTransmittalItem
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]

		public int AssetTransmittalId { get; set; }

		public string AssetCategory { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public int AssetId { get; set; }

		public string AssetName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[Range(1, Int32.MaxValue, ErrorMessage ="Min value 1")]
		public int Qty { get; set; }

	}
}
