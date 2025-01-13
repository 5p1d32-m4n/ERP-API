using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Assets
{
    public class AssetTransmittal
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Title { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProjectName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public DateTime DateCreated { get; set; }

        public string CopiesTo { get; set; }

        public string Transmit { get; set; }

        public string SubmittedFor { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string FromName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ToName { get; set; }

        public string SentVia { get; set; }

        public List<AssetTransmittalItem> AssetTransmittalItems { get; set; }

    }

}
