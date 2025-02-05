namespace SportsPro.Models
{
    public class IncidentsViewModel
    {
        public string Status { get; set; } = "all";

        IEnumerable<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
