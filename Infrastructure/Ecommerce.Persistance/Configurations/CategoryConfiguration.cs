using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Persistance;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasMany(c => c.Properties)
        .WithOne(p => p.Category);


        Category category1 = new()
        {
            Id = 1,
            Name = "Electronics",
            ParentId = 0,
            Priority = 1,
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };
        Category cat1sub1 = new()
        {
            Id = 2,
            Name = "Computer",
            ParentId = 1,
            Priority = 1,
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };
        Category category2 = new()
        {
            Id = 3,
            Name = "Fashion",
            ParentId = 0,
            Priority = 2,
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };

        Category cat2sub1 = new()
        {
            Id = 4,
            Name = "Women",
            ParentId = 3,
            Priority = 1,
            CreatedTime = DateTime.Now,
            IsDeleted = false
        };

        builder.HasData(category1, category2, cat1sub1, cat2sub1);

    }
}
