namespace Ecommerce.Domain
{
    public class Property : EntityBase
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }

        public Property() { }

        public Property(int categoryId, string title, string value){
            Name = title;
            Value = value;
            CategoryId = categoryId;
        }
    }

}
