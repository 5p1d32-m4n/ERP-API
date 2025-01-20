using ErpApi.Models.Business;

namespace ErpApi.Models.ClientsVendors
{
    public class ClientCreateEditViewModel
    {
        public ClientVendor client { get; set; }
        public IEnumerable<Town> town { get; set; }
        public string alertMessage { get; set;}
	}
}