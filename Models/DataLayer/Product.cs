using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models.DataLayer
{
	public partial class Product
	{
		public Product() => Customers = new HashSet<Customer>();

		[Key]
		public int ProductId { get; set; }

		[StringLength(200)]
		public string Code { get; set; } = string.Empty;

		[StringLength(200)]
		public string Name { get; set; } = string.Empty;

		public double YearlyPrice { get; set; }

		public DateTime? ReleaseDate { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("Products")]
		public ICollection<Customer> Customers { get; set; }
	}
}

