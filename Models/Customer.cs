using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customer
    {
        public Customer() => Products = new HashSet<Product>();

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        [StringLength(51, ErrorMessage = "First name must be 51 characters or less.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter last name.")]
        [StringLength(51, ErrorMessage = "Last name must be 51 characters or less.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(51, ErrorMessage = "Address must be 51 characters or less.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a city")]
        [StringLength(51, ErrorMessage = "City must be 51 characters or less.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a state")]
        [StringLength(51, ErrorMessage = "State must be 51 characters or less.")]
        [DataType(DataType.PostalCode)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a postal code.")]
        [StringLength(21, ErrorMessage = "Postal code must be 21 characters or less.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a country")]
        public string Country { get; set; } = string.Empty;

        [StringLength(51, ErrorMessage = "Email must be 51 characters or less.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; } = string.Empty;

        [StringLength(21, ErrorMessage = "Phone number must be 21 characters or less")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string? PhoneNumber { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Product> Products { get; set; }

    }
}
