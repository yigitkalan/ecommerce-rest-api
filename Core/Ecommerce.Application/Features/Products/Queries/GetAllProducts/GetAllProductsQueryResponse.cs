using Ecommerce.Domain.DTOs;

namespace Ecommerce.Application.Features;
public class GetAllProductsQueryResponse
{
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public BrandDto Brand { get; set; }
}
