using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an open date.")]
        public DateTime OpenDate { get; set; } = DateTime.Now;

        public DateTime? CloseDate { get; set; }

        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

        [Required(ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; } = null!;

        [Required(ErrorMessage = "Please select a technician.")]
        public int TechnicianId { get; set; }

        [ValidateNever]
        public Technician Technician { get; set; } = null!;
    }
}
