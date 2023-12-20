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
            Name = "Battery Life",
            Value = faker.Random.Number(1,64).ToString() + " Hours",
        };

        Property property2 = new Property{
            Id = 2,
            CategoryId = 4,
            Name = "Ram",
            Value = faker.Random.Number(1,64).ToString(),
            IsDeleted = true,
        };

        Property property3 = new Property{
            Id = 3,
            CategoryId = 3,
            Name = "Material",
            Value = faker.Lorem.Word(),
        };

        builder.HasData(property, property2, property3);
    }
}
