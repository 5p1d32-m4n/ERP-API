using System.ComponentModel.DataAnnotations;
using ERP_API.Models.Business;

namespace ERP_API.Models.Projects
{
    public class DesignDiscipline
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public AEDiscipline AEDiscipline { get; set; }
        public int? SubDisciplineId { get; set; }
        public AESubDiscipline AESubDiscipline { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public decimal Percentage { get; set; }
        public decimal Cost { get; set; }
        public decimal Hours { get; set; }
    }
}
