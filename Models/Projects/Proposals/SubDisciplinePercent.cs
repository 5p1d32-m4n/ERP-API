﻿using ErpApi.Models.Business;

namespace ErpApi.Models.Projects.Proposals
{
	public class SubDisciplinePercent
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DisciplinePercentId { get; set; }  // Link back to the parent discipline
		public Discipline Discipline { get; set; }
		public int DisciplineId { get; set; }
		public int SubDisciplineId { get; set; }

		public decimal? Percentage { get; set; }
		public decimal? PotentialDisciplineCost { get; set; }

		// Resource allocation specific to this sub-discipline
		public IEnumerable<ProjectResource> SubDisciplineResources { get; set; } = new List<ProjectResource>();
		public List<ProposalDisciplinePercentDrawing> Drawings { get; set; } = new List<ProposalDisciplinePercentDrawing>();
	}
}
