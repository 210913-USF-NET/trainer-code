using System;
using Models;
using RRBL;
using DL;
namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("Welcome to Restaurant Reviews!");
                Console.WriteLine("[0] Manage Restaurant");
                Console.WriteLine("[1] Leave Reviews");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        //this is an example of dependency injection
                        //I'm "injecting" an instance of business logic layer to restaurant menu, and an implementation of 
                        //IRepo to business logic
                        IRepo dataLayer = new FileRepo();
                        IBL businessLogic = new BL(dataLayer);
                        IMenu restaurantMenu = new RestaurantMenu(businessLogic);

                        restaurantMenu.Start();

                        //4 lines ^ is this line
                        // new RestaurantMenu(new BL(new FileRepo())).Start();
                        break;

                    case "1":
                        Console.WriteLine("you wanted to leave reviews");
                        break;

                    case "x":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("I don't know what you're talking about");
                        break;
                }
            } while (!exit);
        }
    }
}