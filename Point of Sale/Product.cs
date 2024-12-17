using Point_of_Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale
{
    public class Product
    {
        public string Name { get; }
        public string Category { get; }
        public string Description { get; }
        public double Price { get; }
        public Product(string name, string category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
        public static List<Product> Products = new List<Product>
        {
            new Product("Banana", "Grocery", "Cost each", 0.25),
            new Product("Apple", "Grocery", "Cost each", 1.0),
            new Product("Avocado", "Grocery", "Cost each", 2.49),
            new Product("Cucumber", "Grocery", "Cost each", 1.49),
            new Product("Ice cream", "Frozen", "Cost each", 3.99),
            new Product("Frozen Pizza", "Frozen", "Cost each", 6.49),
            new Product("Tater Tots", "Frozen", "Cost each", 5.59),
            new Product("Hot Pockets", "Frozen", "Cost each", 3.15),
            new Product("Bread Loaf", "Bakery", "Cost each", 2.99),
            new Product("Bagel", "Bakery", "Cost each", 1.99),
            new Product("Muffin", "Bakery", "Cost each", 2.29),
            new Product("Doughnut", "Bakery", "Cost each", 2.29),
        };
        public static string DisplayProduct(int index) // made static to access the list without having to create a new Product instance
        {
            if (index >= 0 && index < Products.Count)
            {
                Product product = Products[index];
                return $"{index + 1,-5}\t{product.Name,-15}\t{product.Category,-15}\t{product.Description,-15}\t${product.Price:F2}"; //F2 to show 2 decimal places
            }
            else
            {
                throw new Exception("Invalid product selection");
            }
        }
        public static string DisplayAllProducts() // made static to access the list without having to create a new Product instance
        {
            string productList = "";
            int number = 1;
            foreach (var product in Products)
            {
                productList = productList + $"{number, -5}\t{product.Name,-15}\t{product.Category,-15}\t{product.Description,-15}\t${product.Price:F2}\n";
                number++;
            }
            return productList;
        }
    }
}








