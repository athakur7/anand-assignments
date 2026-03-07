namespace CodeFirstEFDemo.Models
{
    class Category
    {
        public int Id { get; set; } // this will be the primary key by convention
        public string Name { get; set; }
        public List<Product> Products { get; set; } // navigation property for related products
    }
}
