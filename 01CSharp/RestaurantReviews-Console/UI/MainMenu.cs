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
                        MenuFactory.GetMenu("restaurant").Start();
                        break;

                    case "1":
                        MenuFactory.GetMenu("review").Start();
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