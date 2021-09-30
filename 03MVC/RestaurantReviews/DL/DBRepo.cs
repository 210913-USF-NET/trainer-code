using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
//using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private RRDBContext _context;
        public DBRepo(RRDBContext context)
        {
            _context = context;
        }
        public Restaurant AddRestaurant(Restaurant resto)
        {
            Restaurant restoToAdd = new Restaurant(){
                Name = resto.Name,
                City = resto.City ?? "",
                State = resto.State ?? ""
            };
            
            //this method adds the restoToAdd obj to change tracker
            restoToAdd = _context.Add(restoToAdd).Entity;

            //the "changes" don't get executed until you call the SaveChanges method
            _context.SaveChanges();

            //this clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return new Restaurant()
            {
                Id = restoToAdd.Id,
                Name = restoToAdd.Name,
                City = restoToAdd.City,
                State = restoToAdd.State
            };
        }

        public List<Restaurant> GetAllRestaurants()
        {
            //select * from Restaurants in sql query
            //Gets the Entities.Restaurant
            //and we have to convert it to Model.Restaurant
            //.Select() is similar in behavior to .map() is js
            return _context.Restaurants.Select(
                restaurant => new Restaurant() {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    State = restaurant.State,
                    City = restaurant.City
                }
            ).ToList();

            //same result, in query syntax
            // return (from resto in _context.Restaurants select new Model.Restaurant(){
            //     Id = resto.Id,
            //     Name = resto.Name,
            //     State = resto.State,
            //     City = resto.City
            // }).ToList();
        }

        public Restaurant UpdateRestaurant(Restaurant restaurantToUpdate)
        {
            Restaurant restoToUpdate = new Restaurant() {
                Id = restaurantToUpdate.Id,
                Name = restaurantToUpdate.Name,
                City = restaurantToUpdate.City,
                State = restaurantToUpdate.State
            };

            restoToUpdate = _context.Restaurants.Update(restoToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Restaurant() {
                Id = restoToUpdate.Id,
                Name = restoToUpdate.Name,
                City = restoToUpdate.City,
                State = restoToUpdate.State
            };
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            return _context.Restaurants.Where(
                resto => resto.Name.Contains(queryStr) || resto.City.Contains(queryStr) || resto.State.Contains(queryStr)
            ).Select(
                r => new Restaurant(){
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    State = r.State
                }
            ).ToList();
        }

        public Review AddAReview(Review review)
        {
            Review reviewToAdd = new Review(){
                Rating = review.Rating,
                Note = review.Note ?? "",
                RestaurantId = review.RestaurantId
            };
            reviewToAdd = _context.Reviews.Add(reviewToAdd).Entity;
            _context.SaveChanges();

            return new Review() {
                Id = reviewToAdd.Id,
                Rating = reviewToAdd.Rating,
                Note = reviewToAdd.Note
            };
        }

        /// <summary>
        /// returns Model.Restaurant by restaurant Id
        /// </summary>
        /// <param name="id">restuarant Id</param>
        /// <returns>Model.Restaurant</returns>
        public Restaurant GetOneRestaurantById(int id)
        {
            Restaurant restoById = 
                _context.Restaurants
                //this include method joins reviews table with the restaurant table
                //and grabs all reviews that references the selected restaurant
                //by restaurantId
                // .Include("Reviews")
                .Include(r => r.Reviews)
                .FirstOrDefault(r => r.Id == id);

            return new Restaurant() {
                Id = restoById.Id,
                Name = restoById.Name,
                State = restoById.State,
                City = restoById.City,
                Reviews = restoById.Reviews.Select(r => new Review(){
                    Id = r.Id,
                    Rating = r.Rating,
                    Note = r.Note
                }).ToList()
            };
        }
    }
}