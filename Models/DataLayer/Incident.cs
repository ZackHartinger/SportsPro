using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models.DataLayer
{
	public partial class Incident
	{
		[Key]
		public int IncidentId { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public DateTime OpenDate { get; set; } = DateTime.Now;

		public DateTime? CloseDate { get; set; }

		public int CustomerId { get; set; }

		public Customer Customer { get; set; } = null!;

		public int ProductId { get; set; }

		public Product Product { get; set; } = null!;

		public int TechnicianId { get; set; }

		public Technician Technician { get; set; } = null!;
	}
}
