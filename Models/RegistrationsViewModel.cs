namespace SportsPro.Models
{
    public class RegistrationsViewModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public int ProductId { get; set; }

        public Product Product { get; set; } = new Product();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
