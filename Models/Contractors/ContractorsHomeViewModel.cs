namespace STG_ERP.Models.Contractors
{
    public class ContractorsHomeViewModel
    {
        public IEnumerable<ContractorsExpirationAlerts> ContractAlerts { get; set; }

        public IEnumerable<ContractorsExpirationAlerts> MedicalSurveillanceAlerts { get; set; }

        public IEnumerable<ContractorsExpirationAlerts> ComplianceAlerts { get; set; }

        public int ContactorTotalCount { get; set; }

        public int ContactorActiveCount { get; set; }

        public int ContactorInactiveCount { get; set; }

        public List<Contractor> AllContractors { get; set; }

        public List<Contractor> ActiveContractors { get; set; }

        public List<Contractor> InActiveContractors { get; set; }

        public string AlertMessage { get; set; }
    }
}
