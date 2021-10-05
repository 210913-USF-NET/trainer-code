using System;
using RRBL;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        private IBL _bl;
        private RestaurantService _restoService;

        public ReviewMenu(IBL bl, RestaurantService restoService)
        {
            _bl = bl;
            _restoService = restoService;
        }
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
            Console.WriteLine("Search a restaurant");
            List<Restaurant> searchResult = _bl.SearchRestaurant(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No Restaurants :/");
                return;
            }
            Restaurant selectedRestaurant = _restoService.SelectARestaurant("Pick a restaurant to write review for", searchResult);
            Console.WriteLine($"You picked {selectedRestaurant.Name}");

            Review reviewToAdd = new Review();
            reviewToAdd.RestaurantId = selectedRestaurant.Id;
            rating:
            Console.WriteLine("Rating (1-5): ");
            int userRating;
            bool success = int.TryParse(Console.ReadLine(), out userRating);
            //if the parse has not been successful, as in the input was not a number
            if(!success) 
            {
                //let the user know, and kick them back to try again
                Console.WriteLine("Invalid input");
                goto rating;
            }
            try
            {
                //else, assign the number to rating
                reviewToAdd.Rating = userRating;
            }
            catch (InputInvalidException e)
            {
                //user entered integer out of bound
                Console.WriteLine(e.Message);
                goto rating;
            }
            finally
            {
                //when do I use this block?
                //to clean up a resource or finish my thought
                //for example, Log.CloseAndFlush(); to close the logger 
            }
            //I'm done adding my rating
            Console.WriteLine("Notes: ");
            reviewToAdd.Note = Console.ReadLine();

            //this needs rejigging to work with db
            //instead of adding review directly to the restaurant
            //we'll be adding the review to review table
            Review addedReview = _bl.AddAReview(reviewToAdd);

            Console.WriteLine("Review Added successfully");
            Console.WriteLine(addedReview);
        }
    }
}