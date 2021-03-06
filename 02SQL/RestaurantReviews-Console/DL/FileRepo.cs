using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;
using Serilog;

namespace DL
{
    public class FileRepo : IRepo
    {
        //this is a relative path from where the program is running
        //aka UI folder
        private const string filePath = "../DL/Restaurants.json";
        
        //this will hold my serialized objects
        private string jsonString;

        public Review AddAReview(Review review)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new restaurant to json file
        /// </summary>
        /// <param name="resto">restaurant to be added</param>
        /// <returns>the added restaurant</returns>
        public Restaurant AddRestaurant(Restaurant resto)
        {
            Log.Debug("DL is adding a restaurant, {0}", resto.ToString());
            //first, grab all restaurant from the file as List<Restaurant>
            List<Restaurant> allResto = GetAllRestaurants();
            //right now, this is in type of List<Restaurant>
            allResto.Add(resto);

            //serialize 
            jsonString = JsonSerializer.Serialize(allResto);

            //write to a file
            File.WriteAllText(filePath, jsonString);

            return resto;
        }

        /// <summary>
        /// Gets all restaurant from the Restaurants.json file
        /// </summary>
        /// <returns>List of all restaurants</returns>
        public List<Restaurant> GetAllRestaurants()
        {
            //Read the file from the file path
            jsonString = File.ReadAllText(filePath);

            //translate the serialized string into List<Restaurant> object!
            return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        }

        public Restaurant GetOneRestaurantById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            throw new NotImplementedException();
        }

        /*
everything between these two symbols are commented
*/

        /// <summary>
        /// This Method updates restaurant
        /// </summary>
        /// <param name="restaurantToUpdate">Restaurant object to be updated</param>
        /// <returns>Updated restaurant object</returns>
        public Restaurant UpdateRestaurant(Restaurant restaurantToUpdate)
        {
            //first, find the restaurant to update
            //by first, getting all restaurants, using getAllRestaurants method
            //and then use FindIndex method with the lambda expression
            //to get me the location of the restaurant in the list
            //if there is a match
            List<Restaurant> allRestaurants = GetAllRestaurants();
            int restaurantIndex = allRestaurants.FindIndex(r => r.Equals(restaurantToUpdate));

            //update the restaurant in the list itself
            allRestaurants[restaurantIndex] = restaurantToUpdate;

            //serialize 
            jsonString = JsonSerializer.Serialize(allRestaurants);

            //write to a file
            File.WriteAllText(filePath, jsonString);
            
            return restaurantToUpdate;
        }
    }
}