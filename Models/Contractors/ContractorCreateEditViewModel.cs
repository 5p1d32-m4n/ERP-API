using STG_ERP.Models.Business;

namespace STG_ERP.Models.Contractors
{
	public class ContractorCreateEditViewModel
	{
		public Contractor Contractor { get; set; }

		public IEnumerable<Town> Towns { get; set; }

		public IEnumerable<EducationType> EducationTypes { get; set; }

		public string AlertMessage { get; set; }
	}
}
