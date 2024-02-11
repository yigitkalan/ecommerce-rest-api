using Bogus;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Persistance;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);
        Faker faker = new("en");

        Brand brand1 = new()
        {
            Id = 1,
            Name = faker.Company.CompanyName(),
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };

        Brand brand2 = new()
        {
            Id = 2,
            Name = faker.Company.CompanyName(),
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };

        Brand brand3 = new()
        {
            Id = 3,
            Name = faker.Company.CompanyName(),
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };
        builder.HasData(brand1, brand2,brand3);
    }
}
