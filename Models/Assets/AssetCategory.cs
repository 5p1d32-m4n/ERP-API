using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Assets
{
    public class AssetCategory
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string LongName { get; set; }
	}
}
