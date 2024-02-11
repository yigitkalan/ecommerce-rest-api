
namespace Ecommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Priority { get; set; }
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