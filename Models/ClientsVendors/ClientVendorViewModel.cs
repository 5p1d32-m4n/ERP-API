using STG_ERP.Models.Business;

namespace STG_ERP.Models.ClientsVendors
{
	public class ClientVendorViewModel
	{
		public List<ClientVendor> client { get; set; }

		public IEnumerable<Town> town { get; set; }

		public string alertMessage { get; set; }
	}
}
