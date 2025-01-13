namespace STG_ERP.Models.Contractors
{
	public class ContractorsViewModel
	{
		public List<Contractor> Contractors { get; set; }

		public IEnumerable<History> Historys { get; set; }

		public IEnumerable<MedicalSurveillance> MedicalSurveillances { get; set; }

		public IEnumerable<Compliance> Compliances { get; set; }

		public IEnumerable<Profession> Professions { get; set; }

		public IEnumerable<cEducation> Educations { get; set; }

		public IEnumerable<cTraining> Trainings { get; set; }

		public IEnumerable<Document> Documents { get; set; }

		public string AlertMessage { get; set; }

		public string Message { get; set; }

		public int IsActive { get; set; }
	}
}
