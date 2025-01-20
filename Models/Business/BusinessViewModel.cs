namespace ErpApi.Models.Business
{
    public class BusinessViewModel
	{
		public Business Business { get; set; }

		//Towns Module
		public IEnumerable<Town> Towns { get; set; }

		//Departments
		public IEnumerable<Department> Departments { get; set; }
		public Department Department { get; set; }

		//Resource Types
		public IEnumerable<ResourceType> ResourceTypes { get; set; }
		public ResourceType ResourceType { get; set; }

		//Resource Titles
		public IEnumerable<Title> ResourceTitles { get; set; }
		public Title Title { get; set; }

		//Disciplines
		public IEnumerable<Discipline> Disciplines { get; set; }
		public Discipline Discipline { get; set; }

		#region Sectors
		//Sectors
		public IEnumerable<SectorCategory> sectorCategories { get; set; }
		public Sector sector { get; set; }
		public SectorCategory sectorCategory { get; set; }
		#endregion

		//Alert Message
		public string AlertMessage { get; set; }
	}
}
