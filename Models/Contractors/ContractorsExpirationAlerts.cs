using Microsoft.VisualBasic;

namespace STG_ERP.Models.Contractors
{
    public class ContractorsExpirationAlerts
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractNameNumber { get; set; }

        public string ExpType { get; set; }

        public string ExpTitle { get; set; }

        public DateTime ExpDate { get; set; }
      
        public string RemainingDays { get; set; }

        public bool Expired { get; set; }

        public string AlertType { get; set; }
    }
}
