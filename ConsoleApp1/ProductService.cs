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
        }

        public void AddProduct(string name, ProductType type,decimal quantity,decimal price)
        {
            products.Add(new Product(name, type, quantity, price));
            Console.WriteLine("Product has added ");
        }

        public bool RemoveProduct(string name)
        {
            Product productToRemove = products.Find(p => p.Name == name);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"Product has been removed:{name}.");
                return true;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return false;
            }

        }

        public void DisplayProducts()
        {
            //я не хотел использовать var но он сам хочет вставиться 
            //вар нам нужен)))
            foreach (var product in products)
            {
                Console.WriteLine($"Product:{product.Name},Type:{product.Type},Mass:{product.Quantity},Price:{product.Price}");
            }
        }
    }
}
