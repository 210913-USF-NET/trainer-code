using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace DL
{
    public class FileRepo : IRepo
    {
        //this is a relative path from where the program is running
        //aka UI folder
        private const string filePath = "../DL/Restaurants.json";
        
        //this will hold my serialized objects
        private string jsonString;
        public Restaurant AddRestaurant(Restaurant resto)
        {
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

        public List<Restaurant> GetAllRestaurants()
        {
            //Read the file from the file path
            jsonString = File.ReadAllText(filePath);

            //translate the serialized string into List<Restaurant> object!
            return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        }
    }
}