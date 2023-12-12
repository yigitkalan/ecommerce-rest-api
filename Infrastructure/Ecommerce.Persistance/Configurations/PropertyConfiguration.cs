using Bogus;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Persistance;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        Faker faker = new Faker();
        Property property = new Property{
            Id = 1,
            CategoryId = 1,
            Name = faker.Commerce.ProductMaterial(),
            Value = faker.Lorem.Word(),
        };

        Property property2 = new Property{
            Id = 2,
            CategoryId = 4,
            Name = faker.Commerce.ProductMaterial(),
            Value = faker.Lorem.Word(),
            IsDeleted = true,
        };

        Property property3 = new Property{
            Id = 3,
            CategoryId = 3,
            Name = faker.Commerce.ProductMaterial(),
            Value = faker.Lorem.Word(),
        };

        builder.HasData(property, property2, property3);
    }
}
