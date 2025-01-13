using ERP_API.Models.Business;

namespace ERP_API.Models.Resources
{
    public class ResourceHomeViewModel
    {
        public string AlertMessage { get; set; }
        public Dictionary<string, int> GenderDistribution { get; set; }
        public Dictionary<string, int> RelationshipStatusDistribution { get; set; }
        public Dictionary<string, int> DepartmentDistribution { get; set; }
        public Dictionary<string, int> ClassificationDistribution { get; set; }
        public Dictionary<int, int> YearsOfServiceDistribution { get; set; }
        public Dictionary<string, int> FLSADistribution { get; set; }
        public Dictionary<string, int> EducationTypeDistribution { get; set; }
        public Dictionary<string, int> ResourceTrainingCounts { get; set; }
        public Dictionary<string, decimal> DepartmentTotalJobYearlyCost { get; set; }
        public Dictionary<string, List<(string SupervisorName, int EmployeeCount)>> SupervisorsByDepartment { get; set; }


        public IEnumerable<Resource> resources { get; set; }
        public IEnumerable<Resource> activeresources { get; set; }
        public IEnumerable<Department> departments { get; set; }
        public IEnumerable<Discipline> disciplines { get; set; }

        public int ResourcesCount { get; set; }
        public int ResourcesActive { get; set; }
        public int JobDisciplines { get; set; }
        public int Departments { get; set; }
    }
}