using Bogus;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Persistance;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.Categories)
        .WithMany(c => c.Products);

        Faker faker = new Faker();

        Product product = new Product
        {
            Id = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Random.Decimal(100, 1000),
            Discount = faker.Random.Decimal(0, 20),
            CreatedTime = DateTime.Now,
            BrandId = 1,
        };

        Product product2 = new Product
        {
            Id = 2,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Random.Decimal(100, 1000),
            Discount = faker.Random.Decimal(0, 20),
            CreatedTime = DateTime.Now,
            BrandId = 3,
        };
        builder.HasData(product, product2);
    }
}
