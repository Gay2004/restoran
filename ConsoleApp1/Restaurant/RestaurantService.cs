using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class RestaurantService
    {
        private List<Restaurant> restaurants;

        public RestaurantService()
        {
            restaurants = new List<Restaurant>();
        }

        public void AddRestaurant(string name, string chefName)
        {
            restaurants.Add(new Restaurant(name, chefName));
            Console.WriteLine($"Restaurant '{name}' with chef {chefName} added successfully.");
        }

        public bool RemoveRestaurant(string name)
        {
            Restaurant restaurantToRemove = restaurants.Find(r => r.Name == name);
            if (restaurantToRemove != null)
            {
                restaurants.Remove(restaurantToRemove);
                Console.WriteLine($"Restaurant '{name}' removed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Restaurant '{name}' not found.");
                return false;
            }
        }

        public bool UpdateRestaurant(string oldName, string newName, string newChefName)
        {
            Restaurant restaurantToUpdate = restaurants.Find(r => r.Name == oldName);
            if (restaurantToUpdate != null)
            {
                restaurantToUpdate.Name = newName;
                restaurantToUpdate.ChefName = newChefName;
                Console.WriteLine($"Restaurant '{oldName}' has been updated to '{newName}' with Chef '{newChefName}'.");
                return true;
            }
            else
            {
                Console.WriteLine($"Restaurant '{oldName}' not found.");
                return false;
            }
        }



        public void DisplayRestaurants()
        {
            Console.WriteLine("List of Restaurants:");
            foreach (Restaurant restaurant in restaurants)
            {
                Console.WriteLine($"Name: {restaurant.Name}, Chef: {restaurant.ChefName}");
            }
        }
    }
}
