
using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Projects.Projects
{
    public class ProjectAEDrawing
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DesignDiscipline DesignDiscipline { get; set; }

        public int DisciplineId { get; set; }
        public AEDiscipline AEDiscipline { get; set; }
        public int AEDisciplineId { get; set; }
        public int AESubDisciplineId { get; set; }

        public int? SubDisciplineId { get; set; }
        public AESubDiscipline AESubDiscipline { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string PageNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string PageTitle { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ResourceName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Enter valid data")]
        public decimal Hours { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Enter valid data")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Enter valid data")]
        public decimal Multiplier { get; set; }
        public decimal BillingRate { get; set; }
        public decimal TotalCost { get; set; }
        public int DesignDisciplineId { get; set; }
    }
}
