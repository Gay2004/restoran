using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ывц 
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            productService.AddProduct("BEEF", ProductType.Meat, 500, 500);
            productService.AddProduct("Carrot", ProductType.Vegetable, 25, 125);
            productService.AddProduct("Apple", ProductType.Fruit, 10, 150);
            productService.AddProduct("Pepper", ProductType.Spice, 25, 200);

            productService.DisplayProducts();
            productService.RemoveProduct("Apple");
            productService.DisplayProducts();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose one option");
                Console.WriteLine("1: Add a product");
                Console.WriteLine("2: Remove a product");
                Console.WriteLine("3: Update a product");
                Console.WriteLine("4: Exit");
                Console.WriteLine("5: DisplayProducts");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Product Name: ");
                        string nameToAdd = Console.ReadLine();

                        int type_product;
                        while (true)
                        {
                            Console.WriteLine("Type:1.Vegetable,2.Fruit,3.Meat,4.Spice");
                            Console.Write("Product Type (integer): ");
                            if (int.TryParse(Console.ReadLine(), out type_product))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid type input, please enter a valid integer.");
                        }

                        decimal quantity_product;
                        while (true)
                        {
                            Console.Write("Product Mass: ");
                            if (decimal.TryParse(Console.ReadLine(), out quantity_product))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid mass input, please enter a valid decimal.");
                        }

                        decimal priceToAdd;
                        while (true)
                        {
                            Console.Write("Enter product price: ");
                            if (decimal.TryParse(Console.ReadLine(), out priceToAdd))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid price input, please enter a valid decimal.");
                        }
                                                    
                        productService.AddProduct(nameToAdd, (ProductType)type_product, quantity_product, priceToAdd);
                        break;
                    case "2":
                        productService.DisplayProducts();
                        Console.WriteLine("Enter product name to remove: ");
                        string nameToRemove = Console.ReadLine();
                        if (productService.RemoveProduct(nameToRemove))
                        {
                            Console.WriteLine("Product removed.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;
                    case "3":
                        productService.DisplayProducts();
                        Console.Write("Product name to update: ");
                        string nameToUpdate = Console.ReadLine();

                        int newTypeInt;
                        while (true)
                        {
                            Console.WriteLine("Type:1.Vegetable,2.Fruit,3.Meat,4.Spice");
                            Console.Write("Enter new product type (integer): ");
                            if (int.TryParse(Console.ReadLine(), out newTypeInt))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid type input, please enter a valid integer.");
                        }

                        decimal quantityToUpdate;
                        while (true)
                        {
                            Console.Write("Product new Mass to update: ");
                            if (decimal.TryParse(Console.ReadLine(), out quantityToUpdate))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid mass input, please enter a valid decimal.");
                        }

                        decimal newPrice;
                        while (true)
                        {
                            Console.Write("Enter new product price: ");
                            if (decimal.TryParse(Console.ReadLine(), out newPrice))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid price input, please enter a valid decimal.");
                        }

                        if (productService.UpdateProduct(nameToUpdate, (ProductType)newTypeInt, quantityToUpdate, newPrice))
                        {
                            Console.WriteLine("Product has been updated.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;
                    case "4":
                        exit = true;
                        break;


                    case "5":
                        productService.DisplayProducts();
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            }
        }
    }
}
