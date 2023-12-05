namespace Ecommerce.Domain
{
    public class Detail
    {
        public required string Title { get; set; }
        public required string Value { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }


        public Detail(int categoryId, string title, string value){
            Title = title;
            Value = value;
            CategoryId = categoryId;
        }
    }

}
