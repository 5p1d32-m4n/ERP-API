using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Business
{
	//Haz un rename de Departments a Department (Las clases y Modelos siempre van en singular)
    public class Department
    {
        public int Id { get; set; }

		[StringLength(2, ErrorMessage = "Max of 2 digits"), Required(ErrorMessage = "This field is required")]
		public string BusinessId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string Name { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }

		
	}
}
