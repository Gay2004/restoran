using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static Chef chef; // Объявляем шефа на уровне класса

        static void Main(string[] args)
        {
            // Создаем два ресторана с поваром chef
            Restaurant restaurant1 = new Restaurant("KFC", chef);
            Restaurant restaurant2 = new Restaurant("MAC", chef);

            // Создаем список ресторанов
            List<Restaurant> restaurants = new List<Restaurant> { restaurant1, restaurant2 };

            // Создаем сервисы для продуктов и меню
            ProductService productService = new ProductService();
            MenuService menuService = new MenuService();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose one option");
                Console.WriteLine("1: Product operations");
                Console.WriteLine("2: Dish operations");
                Console.WriteLine("3: View restaurants");
                Console.WriteLine("4: Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ProductOperations(productService);
                        break;
                    case "2":
                        DishOperations(menuService, productService);
                        break;
                    case "3":
                        ViewRestaurants(restaurants);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            }
        }

        static void ViewRestaurants(List<Restaurant> restaurants)
        {
            Console.WriteLine("Restaurants:");
            for (int i = 0; i < restaurants.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {restaurants[i].Name}");
            }

            Console.WriteLine("Select an option:");
            Console.WriteLine("1: Add a new restaurant");
            Console.WriteLine("2: Remove a restaurant");
            Console.WriteLine("3: Back to main menu");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

// Создаем объекты повара, официанта и менеджера
            Chef chef = new Chef("John", 2000, "Mon-Fri, 9am-5pm");
            Waiter waiter = new Waiter("Emily", 1500, "Wed-Sun, 4pm-12am");
            Manager manager = new Manager("Alice", 2500, "Mon-Sat, 10am-6pm");
            switch (input)
            {
                case "1":
                    Console.Write("Enter the name of the new restaurant: ");
                    string newRestaurantName = Console.ReadLine();
                    restaurants.Add(new Restaurant(newRestaurantName, chef));
                    Console.WriteLine($"Restaurant '{newRestaurantName}' added.");
                    break;

                case "2":
                    Console.Write("Enter the number of the restaurant to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int restaurantIndex) && restaurantIndex >= 1 && restaurantIndex <= restaurants.Count)
                    {
                        string removedRestaurantName = restaurants[restaurantIndex - 1].Name;
                        restaurants.RemoveAt(restaurantIndex - 1);
                        Console.WriteLine($"Restaurant '{removedRestaurantName}' removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void ProductOperations(ProductService productService)
        {
            Console.WriteLine("\nProduct Operations:");
            Console.WriteLine("1: Add a product");
            Console.WriteLine("2: Remove a product");
            Console.WriteLine("3: Update a product");
            Console.WriteLine("4: Display products");
            Console.WriteLine("5: Back to the main menu");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Product Name: ");
                    string nameToAdd = Console.ReadLine();

                    int typeProduct;
                    while (true)
                    {
                        Console.WriteLine("Type: 1.Vegetable, 2.Fruit, 3.Meat, 4.Spice");
                        Console.Write("Product Type (integer): ");
                        if (int.TryParse(Console.ReadLine(), out typeProduct) && Enum.IsDefined(typeof(ProductType), typeProduct))
                        {
                            break;
                        }
                        Console.WriteLine("Invalid type input, please enter a valid integer.");
                    }

                    decimal quantityProduct;
                    while (true)
                    {
                        Console.Write("Product Mass (grams): ");
                        if (decimal.TryParse(Console.ReadLine(), out quantityProduct) && quantityProduct > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid mass input, please enter a valid positive decimal.");
                    }

                    decimal priceProduct;
                    while (true)
                    {
                        Console.Write("Product Price: ");
                        if (decimal.TryParse(Console.ReadLine(), out priceProduct) && priceProduct > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid price input, please enter a valid positive decimal.");
                    }

                    productService.AddProduct(nameToAdd, (ProductType)typeProduct, quantityProduct, priceProduct);
                    break;
                case "2":
                    productService.DisplayProducts();
                    Console.Write("Enter product name to remove: ");
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
                        Console.WriteLine("Type: 1.Vegetable, 2.Fruit, 3.Meat, 4.Spice");
                        Console.Write("Enter new product type (integer): ");
                        if (int.TryParse(Console.ReadLine(), out newTypeInt) && Enum.IsDefined(typeof(ProductType), newTypeInt))
                        {
                            break;
                        }
                        Console.WriteLine("Invalid type input, please enter a valid integer.");
                    }

                    decimal quantityToUpdate;
                    while (true)
                    {
                        Console.Write("Product new Mass (grams): ");
                        if (decimal.TryParse(Console.ReadLine(), out quantityToUpdate) && quantityToUpdate > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid mass input, please enter a valid positive decimal.");
                    }

                    decimal newPrice;
                    while (true)
                    {
                        Console.Write("Enter new product price: ");
                        if (decimal.TryParse(Console.ReadLine(), out newPrice) && newPrice > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid price input, please enter a valid positive decimal.");
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
                    productService.DisplayProducts();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("INVALID CHOICE");
                    break;
            }
        }

        static void DishOperations(MenuService menuService, ProductService productService)
        {
            Console.WriteLine("\nDish Operations:");
            Console.WriteLine("1: Display dishes");
            Console.WriteLine("2: Add dish");
            Console.WriteLine("3: Remove dish");
            Console.WriteLine("4: Back to main menu");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    menuService.DisplayDishes();
                    break;

                case "2":
                    Console.Write("Enter Name of the dish: ");
                    string dishName = Console.ReadLine();
                    Dish dish = new Dish(dishName);
                    menuService.AddDish(dish);

                    bool addIngredients = true;

                    while (addIngredients)
                    {
                        Console.WriteLine("Available Products:");
                        productService.DisplayProducts();

                        Console.Write("Enter Ingredient Name: ");
                        string ingredientName = Console.ReadLine();

                        Product product = productService.GetProductByName(ingredientName);
                        if (product != null)
                        {
                            decimal quantity;
                            while (true)
                            {
                                Console.Write($"Enter Quantity of {ingredientName} in grams: ");
                                if (decimal.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Invalid quantity input, please enter a valid positive decimal.");
                            }

                            menuService.AddIngredientToDish(dishName, product, quantity);
                            Console.WriteLine($"Updated cost of the dish '{dishName}': {menuService.GetDishByName(dishName).CalculateCost()}");

                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }

                        Console.Write("Add another ingredient? (yes/no): ");
                        string continueInput = Console.ReadLine().ToLower();
                        addIngredients = continueInput == "yes" || continueInput == "y";
                    }
                    break;

                case "3":
                    Console.Write("Enter Name of the dish to remove: ");
                    string dishToRemove = Console.ReadLine();
                    menuService.RemoveDish(dishToRemove);
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("INVALID CHOICE");
                    break;
            }
        }
    }
}
