namespace Ecommerce.Domain
{
    public class Product
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
