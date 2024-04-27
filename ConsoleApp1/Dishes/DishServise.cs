using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Dishes
{
    internal class DishServise
    {
        private List<Dish> dishes;

        public DishService()
        {
            dishes = new List<Dish>();
        }

        public void AddDish(string name, decimal price, List<Product> ingredients)
        {
            dishes.Add(new Dish { Name = name, Price = price, Ingredients = ingredients });
            Console.WriteLine("Dish has been added.");
        }

        public bool RemoveDish(string name)
        {
            Dish dishToRemove = dishes.Find(d => d.Name == name);
            if (dishToRemove != null)
            {
                dishes.Remove(dishToRemove);
                Console.WriteLine($"Dish has been removed: {name}.");
                return true;
            }
            else
            {
                Console.WriteLine("Dish not found.");
                return false;
            }
        }

        public bool UpdateDish(string name, decimal newPrice, List<Product> newIngredients)
        {
            Dish dishToUpdate = dishes.FirstOrDefault(d => d.Name == name);
            if (dishToUpdate != null)
            {
                dishToUpdate.Price = newPrice;
                dishToUpdate.Ingredients = newIngredients;
                Console.WriteLine("Dish has been updated.");
                return true;
            }
            else
            {
                Console.WriteLine("Dish not found.");
                return false;
            }
        }

        public void DisplayDishes()
        {
            foreach (var dish in dishes)
            {
                Console.WriteLine($"Dish: {dish.Name}, Price: {dish.Price:C}");
                Console.WriteLine("Ingredients:");
                foreach (var Product in dish.Ingredients)
                {
                    Console.WriteLine($"- {Product.Product.Name} ({Product.WeightInGrams}g)");
                }
                Console.WriteLine();
            }
        }
    }
}
