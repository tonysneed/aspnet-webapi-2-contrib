namespace AspnetWebApi2Helpers.Sample.Entities
{
    public partial class Product
    {
        public Product()
        {
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
