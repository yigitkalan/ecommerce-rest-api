namespace Ecommerce.Domain
{
    public class Property
    {
        public required string Title { get; set; }
        public required string Value { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }


        public Property(int categoryId, string title, string value){
            Title = title;
            Value = value;
            CategoryId = categoryId;
        }
    }

}
