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
        static void Main(string[] args)
        {
            RestaurantService restaurantService = new RestaurantService();
            ProductService productService = new ProductService();
            MenuService menuService = new MenuService();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose one option");
                Console.WriteLine("1: Product operations");
                Console.WriteLine("2: Dish operations");
                Console.WriteLine("3: Restaurant operation");
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
                        RestaurantOperation(restaurantService);
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

        static void RestaurantOperation(RestaurantService restaurantService)
        {
            Console.WriteLine("\nProduct Operations:");
            Console.WriteLine("1: Add a restaurant");
            Console.WriteLine("2: Remove a restaurant");
            Console.WriteLine("3: Update a restaurant");
            Console.WriteLine("4: Display restaurants");
            Console.WriteLine("5: Back to the main menu");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Write("Enter Restaurant Name: ");
                    string nameToAdd = Console.ReadLine();
                    Console.Write("Enter Chef Name: ");
                    string chefNameToAdd = Console.ReadLine();
                    restaurantService.AddRestaurant(nameToAdd, chefNameToAdd);
                    break;
                case "2":
                    restaurantService.DisplayRestaurants();
                    Console.Write("Enter restaurant name to remove: ");
                    string nameToRemove = Console.ReadLine();
                    if (restaurantService.RemoveRestaurant(nameToRemove))
                    {
                        Console.WriteLine("Restaurant removed.");
                    }
                    else
                    {
                        Console.WriteLine("Restaurant not found.");
                    }
                    break;
                case "3":
                    restaurantService.DisplayRestaurants();
                    Console.Write("Enter restaurant name to update: ");
                    string nameToUpdate = Console.ReadLine();
                    Console.Write("Enter new restaurant name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new chef name: ");
                    string newChefName = Console.ReadLine();
                    if (restaurantService.UpdateRestaurant(nameToUpdate, newName, newChefName))
                    {
                        Console.WriteLine("Restaurant has been updated.");
                    }
                    else
                    {
                        Console.WriteLine("Restaurant not found.");
                    }
                    break;
                case "4":
                    restaurantService.DisplayRestaurants();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("INVALID CHOICE");
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
