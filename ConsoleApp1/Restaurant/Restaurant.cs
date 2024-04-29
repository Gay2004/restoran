using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Restaurant
    {
        public string Name;
        public string ChefName;
        public List<Dish> Menu;

        public Restaurant(string name, string chefName)
        {
            Name = name;
            ChefName = chefName;
            Menu = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            Menu.Add(dish);
        }

        public void RemoveDish(string dishName)
        {
            Dish dishToRemove = Menu.Find(d => d.Name == dishName);
            if (dishToRemove != null)
            {
                Menu.Remove(dishToRemove);
                Console.WriteLine($"Dish '{dishName}' removed from the menu of {Name}.");
            }
            else
            {
                Console.WriteLine($"Dish '{dishName}' not found in the menu of {Name}.");
            }
        }

        public void UpdateDish(string oldDishName, Dish newDish)
        {
            Dish dishToUpdate = Menu.Find(d => d.Name == oldDishName);
            if (dishToUpdate != null)
            {
                Menu[Menu.IndexOf(dishToUpdate)] = newDish;
                Console.WriteLine($"Dish '{oldDishName}' updated in the menu of {Name}.");
            }
            else
            {
                Console.WriteLine($"Dish '{oldDishName}' not found in the menu of {Name}.");
            }
        }


        public void DisplayMenu()
        {
            Console.WriteLine($"Menu of {Name}, Chef: {ChefName}");

            foreach (Dish dish in Menu)
            {
                Console.WriteLine($"{dish.Name}: ${dish.CalculateCost()}");
            }
        }
    }
}