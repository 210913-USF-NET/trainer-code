using System;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("This is review menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Write a review");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        WriteAReview();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("What are you talking about");
                        break;
                }
            } while(!exit);
        }

        private void WriteAReview()
        {
            throw new NotImplementedException();
        }
    }
}