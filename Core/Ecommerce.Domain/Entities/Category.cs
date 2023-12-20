using Ecommerce.Domain;

namespace Ecommerce.Domain
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public required int ParentId { get; set; }
        public required int Priority { get; set; }
        public ICollection<Property> Details { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category() { }
        public Category(int parentId, int priority, string name)
        {
            Name = name;
            Priority = priority;
            ParentId = parentId;
        }
    }

}