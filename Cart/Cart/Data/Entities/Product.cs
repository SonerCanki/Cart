using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ProductName Name is required")]
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public string Action { get; set; }
    }
}
