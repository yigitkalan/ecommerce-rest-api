namespace Ecommerce.Domain
{
    public class Property : EntityBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Property() { }


        public Property(int categoryId, string title, string value){
            Name = title;
            Value = value;
            CategoryId = categoryId;
        }
    }

}
