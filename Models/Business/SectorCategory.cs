using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Business
{
	public class SectorCategory
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		public string Description { get; set; }

		public List<Sector> Sectors { get; set; }

		public static implicit operator string(SectorCategory v)
		{
			throw new NotImplementedException();
		}
	}
}
