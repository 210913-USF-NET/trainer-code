using System;
using Models;
using RRBL;
using System.Collections.Generic;

namespace UI
{
    public class RestaurantMenu : IMenu
    {
        private IBL _bl;
        private RestaurantService _restoService;

        public RestaurantMenu(IBL bl, RestaurantService restoService)
        {
            _bl = bl;
            _restoService = restoService;
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
            //First, I'm going to ask for user to gimme a search term to search for
            //once they select the restaurant
            //I'm going to grab the restaurant
            //and its reviews and display them to user
            Console.WriteLine("Search a restaurant");
            List<Restaurant> searchResult = _bl.SearchRestaurant(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No Restaurants :/");
                return;
            }
            Restaurant selectedRestaurant = _restoService.SelectARestaurant("Pick a restaurant", searchResult);

            selectedRestaurant = _bl.GetOneRestaurantById(selectedRestaurant.Id);
            Console.WriteLine(selectedRestaurant);
            foreach(Review review in selectedRestaurant.Reviews)
            {
                Console.WriteLine(review);
            }
            
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

            Restaurant addedResto = _bl.AddRestaurant(newResto);
            Console.WriteLine($"You created {addedResto}");
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