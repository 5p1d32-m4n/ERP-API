
namespace ERP_API.Models.Projects
{
	public class ServiceType
	{
		public int Id { get; set; }

		public string Name { get; set; }

        public static implicit operator ServiceType(string v)
        {
            throw new NotImplementedException();
        }
    }
}
