using CodeFirstEFDemo;
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();

//// Create category first
//var electronics = new Category { Name = "Electronics" };
//context.Categories.Add(electronics);
//await context.SaveChangesAsync();

//// Now add products
//context.Products.AddRange(
//    new Product { Name = "Laptop", Price = 999.99m, CategoryId = electronics.Id },
//    new Product { Name = "Smartphone", Price = 499.99m, CategoryId = electronics.Id }
//);
//await context.SaveChangesAsync();

// update
//var laptop = await context.Products.FirstAsync(p => p.Name == "Laptop");
//laptop.Price = 65621M;
//await context.SaveChangesAsync();

//// delete
//context.Products.Remove(laptop);
//context.SaveChanges();

// query author with courses
//var authorWithCourses = await context.Authors.Include(x=>x.Courses).ToListAsync();
//foreach (var author in authorWithCourses)
//{
//    Console.WriteLine($"Author: {author.Name}");
//    foreach (var course in author.Courses)
//    {
//        Console.WriteLine($"  Course: {course.Title} - {course.Description} (Level: {course.level})");
//    }
//}

//var newProduct = new Product { Name = "Tablet", Price = 299.99m, CategoryId = 1 };
IProductRepository obj = new ProductRepository(context);

//await obj.AddAsync(newProduct);

//var toUpdate = await obj.GetByIdAsync(newProduct.Id);
//if (toUpdate != null)
//{
//    toUpdate.Price = 250.00m;
//    toUpdate.Name = "Update Tablet";
//    await obj.UpdateAsync(toUpdate);
//}

//var existingProductId = 1002; // use a real ID from DB (e.g., 4, 1002, 1003)

//var toUpdate2 = await obj.GetByIdAsync(existingProductId);
//if (toUpdate2 != null)
//{
//    toUpdate2.Price = 250.00m;
//    toUpdate2.Name = "Tablet2";
//    await obj.UpdateAsync(toUpdate2);
//}
//else
//{
//    Console.WriteLine($"Product with ID {existingProductId} was not found.");
//}

// delete
//await obj.DeleteAsync(4);



// call stored procedure to get all products
var products = await obj.GetAllAsync();
foreach (var product in products)
{
    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, CategoryId: {product.CategoryId}");
}

// call stored procedure to get products by category
var categoryProducts = await obj.GetByCategoryAsync(1);
Console.WriteLine(categoryProducts.Count);

// call stored procedure to get product by id
var productById = await obj.GetByIdAsync(1002);
if (productById != null)
{
    Console.WriteLine($"Product found: {productById.Name}, Price: {productById.Price}");
}
else
{
    Console.WriteLine("Product not found.");
}

// call stored procedure to add a new product
categoryProducts.Add(new Product { Name = "New Product", Price = 123.45m, CategoryId = 1 });

// call stored procedure to update a product
if (productById != null)
{
    productById.Price = 543.21m;
    await obj.UpdateAsync(productById);
}

// call stored procedure to delete a product
if (productById != null)
{
    await obj.DeleteAsync(productById.Id);
}

// call stored procedure to get all products again to see changes
var updatedProducts = await obj.GetAllAsync();

// print all products to see the changes in a single print statement
Console.WriteLine(updatedProducts.Count);


