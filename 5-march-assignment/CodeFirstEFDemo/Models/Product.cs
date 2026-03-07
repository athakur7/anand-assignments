namespace CodeFirstEFDemo.Models
{
    class Product
    {
        public int Id { get; set; }
        // this will be the primary key by convention
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // foreign key to Category
        public Category Category { get; set; } // navigation property to related category
    }
}
