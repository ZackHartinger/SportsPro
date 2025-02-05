namespace SportsPro.Models
{
    public class SportsProSession
	{
		private const string TechnicianKey = "techId";
		private const string CustomerKey = "customerId";
		private ISession session { get; set; }

		public SportsProSession(ISession session) => this.session = session;

		public void SetTechnician(Technician technician)
		{
			session.SetObject(TechnicianKey, technician);
		}

		public Technician GetTechnician() => 
			session.GetObject<Technician>(TechnicianKey) ?? new Technician();

		public void SetTechnicianId(int techId)
		{
			session.SetInt32(TechnicianKey, techId);
		}

		public int? GetTechnicianId() =>
			session.GetInt32(TechnicianKey);
		
			
		public void SetCustomerId(int customerId)
		{
			session.SetInt32(CustomerKey, customerId);
		}

		public int? GetCustomerId() =>
			session.GetInt32(CustomerKey);

	}
}
