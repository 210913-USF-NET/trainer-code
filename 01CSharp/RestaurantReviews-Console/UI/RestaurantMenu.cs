using System;
using Models;

namespace UI
{
    public class RestaurantMenu : IMenu
    {
        public void Start() {
            bool exit = false;
            do
            {
                Console.WriteLine("This is restaurant menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Create Restaurant");
                Console.WriteLine("[1] View all Restaurants");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("You'll be creating restaurant");
                        CreateRestaurant();
                        break;
                    case "1":
                        Console.WriteLine("you'll be viewing all restos");
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("What are you talking about");
                        break;
                }
            } while (!exit);
        }

        private void CreateRestaurant()
        {
            Console.WriteLine("Creating new restaurant");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("State: ");
            string state = Console.ReadLine();

            Restaurant newResto = new Restaurant(name, city, state);

            Console.WriteLine($"You created {newResto.ToString()}");
        }
    }
}