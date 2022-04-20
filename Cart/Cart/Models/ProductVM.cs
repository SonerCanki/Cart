namespace Cart.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public decimal Quantity { get; set; }
    }
}
