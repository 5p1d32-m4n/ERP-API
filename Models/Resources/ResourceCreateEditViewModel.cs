using ErpApi.Models.Business;

namespace ErpApi.Models.Resources
{
	public class ResourceCreateEditViewModel
	{
		public Resource Resource { get; set; }

		public IEnumerable<Town> Towns { get; set; }

		public IEnumerable<ResourceType> ResourceTypes { get; set; }

		public IEnumerable<Discipline> Disciplines { get; set; }

		public IEnumerable<Department> Departments { get; set; }

		public IEnumerable<Title> Titles { get; set; }

		public IEnumerable<Supervisor> Supervisors { get; internal set; }

		public IEnumerable<DriversCategory> DriversCategories { get; internal set; }

		public IEnumerable<EducationType> EducationTypes { get; internal set; }

		public string AlertMessage { get; set; }
	}
}
