﻿using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Business
{
	public class Sector
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }

		public string Description { get; set; }

		public int SectorCategoryId { get; set; }
	}
}

