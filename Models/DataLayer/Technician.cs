using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models.DataLayer
{
	public partial class Technician
	{
		[Key]
		public int TechnicianId { get; set; }

		[StringLength(200)]
		public string Name { get; set; } = string.Empty;

		[StringLength(200)]
		public string Email { get; set; } = string.Empty;

		[StringLength(10)]
		[Phone]
		public string PhoneNumber { get; set; } = string.Empty;

	}
}
