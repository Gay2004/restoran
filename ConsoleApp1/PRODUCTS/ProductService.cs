using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProductService
    {
        private List<Product> products;

        public ProductService()
        {
            products = new List<Product>();

            products.Add(new Product("Tomato", ProductType.Vegetable, 1000, 0.50m));
            products.Add(new Product("Chicken Breast", ProductType.Meat, 500, 5.00m));
            products.Add(new Product("Apple tree", ProductType.Fruit, 200, 3.00m));
            products.Add(new Product("Basil", ProductType.Spice, 100, 1.00m));
        }

        public decimal CalculatePriceWithService(Product product, decimal servicePercent)
        {
            decimal servicePrice = product.Price * (servicePercent / 100);
            decimal totalPrice = product.Price + servicePrice;
            return totalPrice;
        }

        public void AddProduct(string name, ProductType type, decimal quantity, decimal price)
        {
            products.Add(new Product(name, type, quantity, price));
            Console.WriteLine("Product has been added.");
        }

        public bool RemoveProduct(string name)
        {
            Product productToRemove = products.Find(p => p.Name == name);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"Product has been removed: {name}.");
                return true;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return false;
            }
        }

        public bool UpdateProduct(string name, ProductType newType, decimal newQuantity, decimal newPrice)
        {
            Product productToUpdate = products.FirstOrDefault(p => p.Name == name);
            if (productToUpdate != null)
            {
                productToUpdate.Type = newType;
                productToUpdate.Quantity = newQuantity;
                productToUpdate.Price = newPrice;
                Console.WriteLine("Product has been updated.");
                return true;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return false;
            }
        }

        public Product GetProductByName(string name)
        {
            return products.FirstOrDefault(p => p.Name == name);
        }

        public void DisplayProducts()
        {
            List<Product> sortedProducts = products.OrderBy(p => p.Name).ToList();

            foreach (Product product in sortedProducts)
            {
                
                Console.WriteLine($"Product: {product.Name}, Type: {product.Type}, Quantity: {product.Quantity}");
            }
        }
    }
}
