namespace Ecommerce.Domain.Entities
{
    public class Product: EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public ICollection<Category> Categories { get; set; }

        public Product() {
            Categories = new List<Category>();
         }

        public Product(string title, string description, int brandId, decimal price, decimal discount)
        {
            Categories = new List<Category>();
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }

    }
}
