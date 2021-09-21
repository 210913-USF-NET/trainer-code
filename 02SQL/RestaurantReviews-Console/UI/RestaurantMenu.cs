using System;
using Models;
using RRBL;
using System.Collections.Generic;

namespace UI
{
    public class RestaurantMenu : IMenu
    {
        private IBL _bl;

        public RestaurantMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start() {
            bool exit = false;
            do
            {
                Console.WriteLine("This is restaurant menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Create Restaurant");
                Console.WriteLine("[1] View all Restaurants");
                Console.WriteLine("[2] View a Restaurant");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        CreateRestaurant();
                        break;
                    case "1":
                        ViewAllRestaurants();
                        break;
                    case "2":
                        ViewOneRestaurant();
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

        private void ViewOneRestaurant()
        {
            throw new NotImplementedException();
        }

        private void CreateRestaurant()
        {
            Console.WriteLine("Creating new restaurant");
            Restaurant newResto = new Restaurant();
            inputName:
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            try
            {
                newResto.Name = name;
            }
            catch(InputInvalidException e)
            {
                Console.WriteLine(e.Message);
                goto inputName;
            }
            Console.WriteLine("City: ");
            newResto.City = Console.ReadLine();
            Console.WriteLine("State: ");
            newResto.State = Console.ReadLine();

            _bl.AddRestaurant(newResto);
            Console.WriteLine($"You created {newResto}");
        }

        private void ViewAllRestaurants()
        {
            List<Restaurant> allResto = _bl.GetAllRestaurants();
            if(allResto.Count == 0)
            {
                Console.WriteLine("There is no restaurant :/");
            }
            else
            {
                foreach (Restaurant resto in allResto)
                {
                    Console.WriteLine(resto.ToString());
                }
            }
        }
    }
}