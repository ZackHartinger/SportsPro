namespace SportsPro.Models
{
    public class EditIncidentViewModel
    {
        public string Action { get; set; } = string.Empty;

        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<Technician> Technicians { get; set; } = new List<Technician>();

        public IEnumerable<Incident> Incidents { get; set; } = new List<Incident>();

        public Incident Incident { get; set; } = new Incident();

        public string TechnicianName { get; set; } = string.Empty;

        public int TechnicianId { get; set; }
    }
}
