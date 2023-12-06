namespace Ecommerce.Domain
{
    public class Brand : EntityBase
    {
        public Brand(string name){
            Name = name;
        }
        public Brand(){}
        public required string Name { get; set; }

    }
}
