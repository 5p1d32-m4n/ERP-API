namespace ErpApi.Models.Business
{
	public class SectorsViewModel
	{
		public IEnumerable<SectorCategory> sectorCategories { get; set; }

		public Sector sector { get; set; }

		public SectorCategory sectorCategory { get; set; }

		public string AlertMessage { get; set; }
	}
}
