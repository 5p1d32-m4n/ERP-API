using ERP_API.Models.Business;

namespace ERP_API.Models.Contractors
{
	public class ContractorCreateEditViewModel
	{
		public Contractor Contractor { get; set; }

		public IEnumerable<Town> Towns { get; set; }

		public IEnumerable<EducationType> EducationTypes { get; set; }

		public string AlertMessage { get; set; }
	}
}
