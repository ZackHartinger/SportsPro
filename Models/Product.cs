using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Product
    {
        public Product() => Customers = new HashSet<Customer>();
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a code.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a price.")]
        public double YearlyPrice { get; set; }

        [Required(ErrorMessage = "Please enter a release year.")]
        public DateTime? ReleaseDate { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
