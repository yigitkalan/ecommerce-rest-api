
namespace Ecommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Priority { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Product> Products { get; set; } 
        public Category() {
            Properties = new List<Property>();
            Products = new List<Product>();
         }
        public Category(int parentId, int priority, string name)
        {

            Properties = new List<Property>();
            Products = new List<Product>();
            Name = name;
            Priority = priority;
            ParentId = parentId;
        }
    }

}